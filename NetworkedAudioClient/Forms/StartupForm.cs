using System;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace NetworkedAudioClient.Forms
{
    public partial class StartupForm : Form
    {
        TransmitForm transmitForm;
        UdpClient client;
        IPEndPoint multicastEndpoint;

        Dictionary<long, string> names;
        Dictionary<long, IPEndPoint> addresses;

        public void PrepareLoopback()
        {
            var capture = new WasapiLoopbackCapture();
            capture.DataAvailable += (sender, args) => {
                Console.WriteLine("Retrieved {} bytes", args.BytesRecorded);
            };
            capture.StartRecording();
        }

        public StartupForm()
        {
            InitializeComponent();
            RefreshDevices();

            client = new UdpClient();
            var groupAddr = IPAddress.Parse("239.101.13.37");
            client.JoinMulticastGroup(groupAddr);
            client.EnableBroadcast = true;
            multicastEndpoint = new IPEndPoint(groupAddr, 11111);

            names = new Dictionary<long, string>();
            addresses = new Dictionary<long, IPEndPoint>();

            DiscoveryWorker.RunWorkerAsync();

            EmitBroadcastMessage();
        }

        public void RefreshDevices()
        {
            var enumerator = new MMDeviceEnumerator();
            InputDevicesComboBox.Items.Clear();
            OutputDevicesComboBox.Items.Clear();
            int maxWidth = 0;
            foreach (var device in enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                maxWidth = Math.Max(maxWidth, TextRenderer.MeasureText(device.DeviceFriendlyName, InputDevicesComboBox.Font).Width);
                InputDevicesComboBox.Items.Add(device);
                OutputDevicesComboBox.Items.Add(device);
            }

            Console.WriteLine("Max width = {0}", maxWidth);
            InputDevicesComboBox.DropDownWidth = maxWidth * 2;
            OutputDevicesComboBox.DropDownWidth = maxWidth * 2;

            var defaultDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            var deviceEnum = InputDevicesComboBox.Items.GetEnumerator();
            for (int i = 0; i < InputDevicesComboBox.Items.Count; i++)
            {
                deviceEnum.MoveNext();
                if (((MMDevice)deviceEnum.Current).DeviceFriendlyName == defaultDevice.DeviceFriendlyName)
                {
                    InputDevicesComboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if(InputDevicesComboBox.SelectedItem == null || OutputDevicesComboBox.SelectedItem == null)
            {
                MessageBox.Show("select a device, dummy", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            transmitForm = new TransmitForm((MMDevice)InputDevicesComboBox.SelectedItem, (MMDevice)OutputDevicesComboBox.SelectedItem, MuteAudioCheckBox.Checked, (int)BitrateUpDown.Value);
            this.Hide();
            transmitForm.ShowDialog();
            this.Show();
        }

        private void RefreshDevicesButton_Click(object sender, EventArgs e)
        {
            RefreshDevices();
        }

        private void EmitBroadcastMessage()
        {
            client.Send(Encoding.ASCII.GetBytes("Adv"), 3, multicastEndpoint);
        }

        private delegate void RefreshDevicesListDelegate();

        private void RefreshDevicesList()
        {
            DiscoveredDevices.Items.Clear();
            foreach (var item in names)
            {
                DiscoveredDevices.Items.Add(item.Value);
            }
        }

        private void DiscoveryWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IPEndPoint remoteEndpoint = new IPEndPoint(IPAddress.Any, 50);
            while (true)
            {
                byte[] data = client.Receive(ref remoteEndpoint);
                if (data.Length >= 12)
                {
                    try
                    {
                        var code = Encoding.ASCII.GetString(data.Take(3).ToArray());
                        if(code != "Hey")
                        {
                            continue;
                        }
                        var id = BitConverter.ToInt64(data.Skip(3).Take(8).ToArray(), 0);
                        var name = Encoding.ASCII.GetString(data.Skip(11).ToArray());
                        names[id] = name;
                        addresses[id] = remoteEndpoint;
                        DiscoveryWorker.ReportProgress(1);
                        DiscoveryWorker.ReportProgress(0);
                    }
                    catch
                    {
                        Console.WriteLine("got an invalid packet");
                        continue;
                    }

                }
            }
        }

        private void RediscoverNetworkDevices_Click(object sender, EventArgs e)
        {
            DiscoveredDevices.Items.Clear();
            names.Clear();
            addresses.Clear();
            EmitBroadcastMessage();
        }

        private void DiscoveryWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            RefreshDevicesList();
        }
    }
}
