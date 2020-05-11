using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Concentus.Structs;
using NetworkedAudioClient.Resampler;
using System.Net.Sockets;
using System.Net;
using Sodium;
using System.Text;
using System.Threading;

namespace NetworkedAudioClient.Forms
{
    public partial class TransmitForm : Form
    {
        MMDevice speaker, microphone;
        bool wasAudioMuted, muteAudio;
        WasapiLoopbackCapture capture;
        MemoryStream stream;
        WaveFormat outFormat;
        WdlResampler resampler;
        WaveStream waveStream;
        WasapiOut output;
        OpusEncoder encoder;
        OpusDecoder decoder;
        UdpClient audioClient;
        BufferedWaveProvider waveProvider;

        KeyPair localKeyPair;
        byte[] remotePublicKey;
        byte[] sessionID;
        UdpClient client;
        IPEndPoint endpoint;
        ulong seq = 0;
        Thread receiverThread;

        private void ReceiverLoop()
        {
            audioClient = new UdpClient(4321);
            var endpoint = new IPEndPoint(IPAddress.Any, 1);
            while (true)
            {
                var data = new byte[0];
                try
                {
                    data = audioClient.Receive(ref endpoint);
                }
                catch
                {
                    return;
                }
                var method = Encoding.ASCII.GetString(data.Take(3).ToArray());
                if (method != "Aud")
                {
                    continue;
                }
                var session = data.Skip(3).Take(4).ToArray();
                var seq = data.Skip(7).Take(8).ToArray();
                var nonce = data.Skip(15).Take(24).ToArray();
                var encryptedData = data.Skip(39).ToArray();
                var opusData = new byte[0];
                try
                {
                    opusData = PublicKeyBox.Open(encryptedData, nonce, localKeyPair.PrivateKey, remotePublicKey);
                }
                catch
                {
                    continue;
                }
                var samples = new short[960];
                decoder.Decode(opusData, 0, opusData.Length, samples, 0, 480);
                var sampleBuffer = new byte[1920];
                for(int i = 0; i < 960; i++)
                {
                    var splitSample = BitConverter.GetBytes(samples[i]);
                    sampleBuffer[i * 2] = splitSample[0];
                    sampleBuffer[i * 2 + 1] = splitSample[1];
                }
                waveProvider.AddSamples(sampleBuffer, 0, 1920);

                var ack = Encoding.ASCII.GetBytes("Ack")
                    .Concat(seq)
                    .ToArray();
                audioClient.Send(ack, ack.Length, endpoint);
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TransmitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            audioClient.Close();
            output.Stop();
            capture.StopRecording();
            receiverThread.Abort();
            speaker.AudioEndpointVolume.Mute = muteAudio ? wasAudioMuted : speaker.AudioEndpointVolume.Mute;
        }

        private void SendData(byte[] encodedData)
        {
            var nonce = PublicKeyBox.GenerateNonce();
            var encrypted = PublicKeyBox.Create(encodedData, nonce, localKeyPair.PrivateKey, remotePublicKey);
            var packet = Encoding.ASCII.GetBytes("Aud")
                .Concat(sessionID)
                .Concat(BitConverter.GetBytes(seq))
                .Concat(nonce)
                .Concat(encrypted)
                .ToArray();
            seq++;
            client.Send(packet, packet.Length);
        }

        public TransmitForm(MMDevice speaker,
                            MMDevice microphone,
                            bool muteAudio,
                            int bitrate,
                            UdpClient client,
                            IPEndPoint endpoint,
                            byte[] sessionID,
                            KeyPair localKey,
                            byte[] remotePublicKey)
        {
            this.speaker = speaker;
            this.microphone = microphone;
            this.muteAudio = muteAudio;
            wasAudioMuted = speaker.AudioEndpointVolume.Mute;
            speaker.AudioEndpointVolume.Mute = muteAudio ? true : this.wasAudioMuted;
            this.client = client;
            this.endpoint = endpoint;
            this.sessionID = sessionID;
            this.localKeyPair = localKey;
            this.remotePublicKey = remotePublicKey;
            InitializeComponent();

            stream = new MemoryStream();
            outFormat = new WaveFormat(48000, 2);
            
            capture = new WasapiLoopbackCapture(speaker);
            waveStream = new RawSourceWaveStream(stream, capture.WaveFormat);
            resampler = new WdlResampler();
            resampler.SetMode(true, 0, false);
            resampler.SetFeedMode(true);
            resampler.SetRates(capture.WaveFormat.SampleRate, outFormat.SampleRate);

            

            output = new WasapiOut(microphone, AudioClientShareMode.Shared, true, 0);
            waveProvider = new BufferedWaveProvider(new WaveFormat(48000, 2));
            waveProvider.BufferLength = 100000;
            waveProvider.DiscardOnBufferOverflow = true;
            output.Init(waveProvider);
            output.Play();
            encoder = new OpusEncoder(48000, 2, Concentus.Enums.OpusApplication.OPUS_APPLICATION_AUDIO)
            {
                Bitrate = bitrate * 1000
            };
            decoder = new OpusDecoder(48000, 2);
            capture.DataAvailable += DataAvailable;
            capture.StartRecording();

            receiverThread = new Thread(new ThreadStart(ReceiverLoop));
            receiverThread.Start();
        }

        private void DataAvailable(object sender, WaveInEventArgs e)
        {
            // WaveBuffer is broken.
            //var buffer = new WaveBuffer(e.Buffer);
            
            var buffer = new float[e.BytesRecorded / 4];
            for (int i = 0; i < e.BytesRecorded; i += 4)
            {
                buffer[i / 4] = BitConverter.ToSingle(e.Buffer, i) * SpeakersVolumeSlider.Volume;
            }
            // This peak detection doesn't work correctly
            {
                float peakL = 0, peakR = 0;
                for (int i = 0; i < buffer.Length; i += 2)
                {
                    peakL += Math.Abs(buffer[i]);
                }
                for (int i = 1; i < buffer.Length; i += 2)
                {
                    peakR += Math.Abs(buffer[i]);
                }
                SpeakersLeftChannel.Amplitude = peakL / (buffer.Length / 2);
                SpeakersRightChannel.Amplitude = peakR / (buffer.Length / 2);
            }
            int framesAvailable = e.BytesRecorded * 8 / capture.WaveFormat.BitsPerSample / 2;
            //Console.WriteLine("Got {0} samples per channel", framesAvailable);
            float[] inBuffer;
            int inBufferOffset;
            int inNeeded = resampler.ResamplePrepare(framesAvailable, capture.WaveFormat.Channels, out inBuffer, out inBufferOffset);
            Array.Copy(buffer, 0, inBuffer, inBufferOffset, inNeeded * 2);
            float[] outBuffer = new float[framesAvailable * 4];
            int outAvailable = resampler.ResampleOut(outBuffer, 0, inNeeded, framesAvailable * 2, outFormat.Channels);
            //Console.WriteLine("Got {0} samples after resample", outAvailable);

            for (int i = 0; i < framesAvailable * 2; i += 960)
            {
                var resampledDataTemp = outBuffer.Skip(i).Take(Math.Min(960, (outAvailable * 2 - i))).ToArray();
                var resampledPaddedData = new float[960];
                var output = new byte[1276];
                Array.Copy(resampledDataTemp, resampledPaddedData, resampledDataTemp.Length);
                int encoded = encoder.Encode(resampledPaddedData, 0, 480, output, 0, 1276);
                SendData(output.Take(encoded).ToArray());
                //Console.WriteLine("Encoded packet of {0} bytes", encoded);
                
                // TODO: Send encoded data to the client
            }
        }
    }
}
