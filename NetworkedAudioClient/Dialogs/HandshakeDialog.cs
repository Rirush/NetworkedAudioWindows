using Sodium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkedAudioClient.Dialogs
{
    public partial class HandshakeDialog : Form
    {
        public UdpClient socket;
        public byte[] sessionID;
        public KeyPair localPair;
        public byte[] remotePublicKey;
        byte[] randomID;
        string name;
        IPEndPoint endpoint;

        public HandshakeDialog(UdpClient socket, IPEndPoint endpoint, string name)
        {
            InitializeComponent();
            this.socket = socket;
            this.socket.Connect(endpoint);
            randomID = new byte[8];
            (new RNGCryptoServiceProvider()).GetBytes(randomID);
            this.name = name;
            this.endpoint = endpoint;
            HandshakeWorker.RunWorkerAsync();
        }

        private void HandshakeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            IPEndPoint a = new IPEndPoint(IPAddress.Any, 1);
            localPair = PublicKeyBox.GenerateKeyPair();
            var message = Encoding.ASCII.GetBytes("Key");
            message = message.Concat(randomID)
                    .Concat(localPair.PublicKey)
                    .Concat(Encoding.ASCII.GetBytes(name))
                    .ToArray();
            socket.Send(message, message.Length);
            var response = socket.Receive(ref a);
            if (Encoding.ASCII.GetString(response.Take(3).ToArray()) != "Key" || response.Length != 35)
            {
                HandshakeWorker.ReportProgress(2);
                return;
            }
            remotePublicKey = response.Skip(3).Take(32).ToArray();
            message = Encoding.ASCII.GetBytes("Ses").Concat(randomID).ToArray();
            socket.Send(message, message.Length);
            response = socket.Receive(ref a);
            if (Encoding.ASCII.GetString(response.Take(3).ToArray()) != "AOk" || response.Length != 7)
            {
                HandshakeWorker.ReportProgress(2);
                return;
            }
            sessionID = response.Skip(3).Take(4).ToArray();
            HandshakeWorker.ReportProgress(1);
        }

        private void HandshakeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                case 2:
                    DialogResult = DialogResult.Abort;
                    Close();
                    return;
            }
        }
    }
}
