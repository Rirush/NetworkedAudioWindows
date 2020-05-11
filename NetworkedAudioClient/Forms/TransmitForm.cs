using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Concentus.Structs;
using NetworkedAudioClient.Resampler;

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
        OpusEncoder encoder;

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TransmitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            capture.StopRecording();
            speaker.AudioEndpointVolume.Mute = muteAudio ? wasAudioMuted : speaker.AudioEndpointVolume.Mute;
        }

        public TransmitForm(MMDevice speaker, MMDevice microphone, bool muteAudio, int bitrate)
        {
            this.speaker = speaker;
            this.microphone = microphone;
            this.muteAudio = muteAudio;
            wasAudioMuted = speaker.AudioEndpointVolume.Mute;
            speaker.AudioEndpointVolume.Mute = muteAudio ? true : this.wasAudioMuted;
            InitializeComponent();

            stream = new MemoryStream();
            outFormat = new WaveFormat(48000, 2);
            capture = new WasapiLoopbackCapture(speaker);
            waveStream = new RawSourceWaveStream(stream, capture.WaveFormat);
            resampler = new WdlResampler();
            resampler.SetMode(true, 0, false);
            resampler.SetFeedMode(true);
            resampler.SetRates(capture.WaveFormat.SampleRate, outFormat.SampleRate);

            encoder = new OpusEncoder(48000, 2, Concentus.Enums.OpusApplication.OPUS_APPLICATION_AUDIO)
            {
                Bitrate = bitrate * 1000
            };
            capture.DataAvailable += DataAvailable;
            capture.StartRecording();
        }

        private void DataAvailable(object sender, WaveInEventArgs e)
        {
            // WaveBuffer is broken.
            //var buffer = new WaveBuffer(e.Buffer);
            var buffer = new float[e.BytesRecorded / 2];
            for (int i = 0; i < e.BytesRecorded; i += 2)
            {
                short sample = (short)((e.Buffer[i + 1] << 8) | (e.Buffer[i]));
                buffer[i / 2] = sample / 32768f * SpeakersVolumeSlider.Volume;
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

            for (int i = 0; i < outAvailable * 2; i += 960)
            {
                var resampledDataTemp = outBuffer.Skip(i).Take(Math.Min(960, (outAvailable * 2 - i))).ToArray();
                var resampledPaddedData = new float[960];
                var output = new byte[1276];
                Array.Copy(resampledDataTemp, resampledPaddedData, resampledDataTemp.Length);
                int encoded = encoder.Encode(resampledPaddedData, 0, 480, output, 0, 1276);
                //Console.WriteLine("Encoded packet of {0} bytes", encoded);
                
                // TODO: Send encoded data to the client
            }
        }
    }
}
