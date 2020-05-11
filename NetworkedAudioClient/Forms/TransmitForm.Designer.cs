namespace NetworkedAudioClient.Forms
{
    partial class TransmitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogBox = new System.Windows.Forms.ListBox();
            this.StatusGroupBox = new System.Windows.Forms.GroupBox();
            this.MicrophoneVolumeSlider = new NAudio.Gui.VolumeSlider();
            this.SpeakersVolumeSlider = new NAudio.Gui.VolumeSlider();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ConnectivityLogsLabel = new System.Windows.Forms.Label();
            this.MicrophoneRightChannel = new NAudio.Gui.VolumeMeter();
            this.MicrophoneLeftChannel = new NAudio.Gui.VolumeMeter();
            this.SpeakersRightChannel = new NAudio.Gui.VolumeMeter();
            this.SpeakersLeftChannel = new NAudio.Gui.VolumeMeter();
            this.MicrophoneLabel = new System.Windows.Forms.Label();
            this.SpeakersLabel = new System.Windows.Forms.Label();
            this.LostPacketsLabel = new System.Windows.Forms.Label();
            this.LostPacketsTooltipLabel = new System.Windows.Forms.Label();
            this.LatencyLabel = new System.Windows.Forms.Label();
            this.LatencyTooltipLabel = new System.Windows.Forms.Label();
            this.StatusGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogBox
            // 
            this.LogBox.FormattingEnabled = true;
            this.LogBox.Location = new System.Drawing.Point(6, 283);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(187, 173);
            this.LogBox.TabIndex = 0;
            // 
            // StatusGroupBox
            // 
            this.StatusGroupBox.Controls.Add(this.MicrophoneVolumeSlider);
            this.StatusGroupBox.Controls.Add(this.SpeakersVolumeSlider);
            this.StatusGroupBox.Controls.Add(this.DisconnectButton);
            this.StatusGroupBox.Controls.Add(this.ConnectivityLogsLabel);
            this.StatusGroupBox.Controls.Add(this.MicrophoneRightChannel);
            this.StatusGroupBox.Controls.Add(this.LogBox);
            this.StatusGroupBox.Controls.Add(this.MicrophoneLeftChannel);
            this.StatusGroupBox.Controls.Add(this.SpeakersRightChannel);
            this.StatusGroupBox.Controls.Add(this.SpeakersLeftChannel);
            this.StatusGroupBox.Controls.Add(this.MicrophoneLabel);
            this.StatusGroupBox.Controls.Add(this.SpeakersLabel);
            this.StatusGroupBox.Controls.Add(this.LostPacketsLabel);
            this.StatusGroupBox.Controls.Add(this.LostPacketsTooltipLabel);
            this.StatusGroupBox.Controls.Add(this.LatencyLabel);
            this.StatusGroupBox.Controls.Add(this.LatencyTooltipLabel);
            this.StatusGroupBox.Location = new System.Drawing.Point(12, 12);
            this.StatusGroupBox.Name = "StatusGroupBox";
            this.StatusGroupBox.Size = new System.Drawing.Size(200, 491);
            this.StatusGroupBox.TabIndex = 1;
            this.StatusGroupBox.TabStop = false;
            this.StatusGroupBox.Text = "Status";
            // 
            // MicrophoneVolumeSlider
            // 
            this.MicrophoneVolumeSlider.Location = new System.Drawing.Point(101, 226);
            this.MicrophoneVolumeSlider.Name = "MicrophoneVolumeSlider";
            this.MicrophoneVolumeSlider.Size = new System.Drawing.Size(86, 20);
            this.MicrophoneVolumeSlider.TabIndex = 12;
            // 
            // SpeakersVolumeSlider
            // 
            this.SpeakersVolumeSlider.Location = new System.Drawing.Point(9, 226);
            this.SpeakersVolumeSlider.Name = "SpeakersVolumeSlider";
            this.SpeakersVolumeSlider.Size = new System.Drawing.Size(86, 20);
            this.SpeakersVolumeSlider.TabIndex = 11;
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(6, 462);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(188, 23);
            this.DisconnectButton.TabIndex = 10;
            this.DisconnectButton.Text = "Stop";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // ConnectivityLogsLabel
            // 
            this.ConnectivityLogsLabel.AutoSize = true;
            this.ConnectivityLogsLabel.Location = new System.Drawing.Point(3, 267);
            this.ConnectivityLogsLabel.Name = "ConnectivityLogsLabel";
            this.ConnectivityLogsLabel.Size = new System.Drawing.Size(85, 13);
            this.ConnectivityLogsLabel.TabIndex = 9;
            this.ConnectivityLogsLabel.Text = "Connectivity log:";
            // 
            // MicrophoneRightChannel
            // 
            this.MicrophoneRightChannel.Amplitude = 0F;
            this.MicrophoneRightChannel.Location = new System.Drawing.Point(146, 62);
            this.MicrophoneRightChannel.MaxDb = 18F;
            this.MicrophoneRightChannel.MinDb = -60F;
            this.MicrophoneRightChannel.Name = "MicrophoneRightChannel";
            this.MicrophoneRightChannel.Size = new System.Drawing.Size(41, 158);
            this.MicrophoneRightChannel.TabIndex = 8;
            this.MicrophoneRightChannel.Text = "volumeMeter2";
            // 
            // MicrophoneLeftChannel
            // 
            this.MicrophoneLeftChannel.Amplitude = 0F;
            this.MicrophoneLeftChannel.Location = new System.Drawing.Point(102, 62);
            this.MicrophoneLeftChannel.MaxDb = 18F;
            this.MicrophoneLeftChannel.MinDb = -60F;
            this.MicrophoneLeftChannel.Name = "MicrophoneLeftChannel";
            this.MicrophoneLeftChannel.Size = new System.Drawing.Size(41, 158);
            this.MicrophoneLeftChannel.TabIndex = 7;
            this.MicrophoneLeftChannel.Text = "volumeMeter1";
            // 
            // SpeakersRightChannel
            // 
            this.SpeakersRightChannel.Amplitude = 0F;
            this.SpeakersRightChannel.Location = new System.Drawing.Point(54, 62);
            this.SpeakersRightChannel.MaxDb = 0F;
            this.SpeakersRightChannel.MinDb = -36F;
            this.SpeakersRightChannel.Name = "SpeakersRightChannel";
            this.SpeakersRightChannel.Size = new System.Drawing.Size(41, 158);
            this.SpeakersRightChannel.TabIndex = 6;
            this.SpeakersRightChannel.Text = "volumeMeter2";
            // 
            // SpeakersLeftChannel
            // 
            this.SpeakersLeftChannel.Amplitude = 0F;
            this.SpeakersLeftChannel.Location = new System.Drawing.Point(9, 62);
            this.SpeakersLeftChannel.MaxDb = 0F;
            this.SpeakersLeftChannel.MinDb = -36F;
            this.SpeakersLeftChannel.Name = "SpeakersLeftChannel";
            this.SpeakersLeftChannel.Size = new System.Drawing.Size(41, 158);
            this.SpeakersLeftChannel.TabIndex = 2;
            this.SpeakersLeftChannel.Text = "volumeMeter1";
            // 
            // MicrophoneLabel
            // 
            this.MicrophoneLabel.AutoSize = true;
            this.MicrophoneLabel.Location = new System.Drawing.Point(98, 46);
            this.MicrophoneLabel.Name = "MicrophoneLabel";
            this.MicrophoneLabel.Size = new System.Drawing.Size(66, 13);
            this.MicrophoneLabel.TabIndex = 5;
            this.MicrophoneLabel.Text = "Microphone:";
            // 
            // SpeakersLabel
            // 
            this.SpeakersLabel.AutoSize = true;
            this.SpeakersLabel.Location = new System.Drawing.Point(6, 46);
            this.SpeakersLabel.Name = "SpeakersLabel";
            this.SpeakersLabel.Size = new System.Drawing.Size(55, 13);
            this.SpeakersLabel.TabIndex = 4;
            this.SpeakersLabel.Text = "Speakers:";
            // 
            // LostPacketsLabel
            // 
            this.LostPacketsLabel.AutoSize = true;
            this.LostPacketsLabel.Location = new System.Drawing.Point(99, 31);
            this.LostPacketsLabel.Name = "LostPacketsLabel";
            this.LostPacketsLabel.Size = new System.Drawing.Size(54, 13);
            this.LostPacketsLabel.TabIndex = 3;
            this.LostPacketsLabel.Text = "0 packets";
            // 
            // LostPacketsTooltipLabel
            // 
            this.LostPacketsTooltipLabel.AutoSize = true;
            this.LostPacketsTooltipLabel.Location = new System.Drawing.Point(22, 31);
            this.LostPacketsTooltipLabel.Name = "LostPacketsTooltipLabel";
            this.LostPacketsTooltipLabel.Size = new System.Drawing.Size(71, 13);
            this.LostPacketsTooltipLabel.TabIndex = 2;
            this.LostPacketsTooltipLabel.Text = "Lost packets:";
            // 
            // LatencyLabel
            // 
            this.LatencyLabel.AutoSize = true;
            this.LatencyLabel.Location = new System.Drawing.Point(99, 16);
            this.LatencyLabel.Name = "LatencyLabel";
            this.LatencyLabel.Size = new System.Drawing.Size(29, 13);
            this.LatencyLabel.TabIndex = 1;
            this.LatencyLabel.Text = "0 ms";
            // 
            // LatencyTooltipLabel
            // 
            this.LatencyTooltipLabel.AutoSize = true;
            this.LatencyTooltipLabel.Location = new System.Drawing.Point(6, 16);
            this.LatencyTooltipLabel.Name = "LatencyTooltipLabel";
            this.LatencyTooltipLabel.Size = new System.Drawing.Size(87, 13);
            this.LatencyTooltipLabel.TabIndex = 0;
            this.LatencyTooltipLabel.Text = "Average latency:";
            // 
            // TransmitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 515);
            this.Controls.Add(this.StatusGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TransmitForm";
            this.Text = "Audio Transmission";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransmitForm_FormClosing);
            this.StatusGroupBox.ResumeLayout(false);
            this.StatusGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LogBox;
        private System.Windows.Forms.GroupBox StatusGroupBox;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Label ConnectivityLogsLabel;
        private NAudio.Gui.VolumeMeter MicrophoneRightChannel;
        private NAudio.Gui.VolumeMeter MicrophoneLeftChannel;
        private NAudio.Gui.VolumeMeter SpeakersRightChannel;
        private NAudio.Gui.VolumeMeter SpeakersLeftChannel;
        private System.Windows.Forms.Label MicrophoneLabel;
        private System.Windows.Forms.Label SpeakersLabel;
        private System.Windows.Forms.Label LostPacketsLabel;
        private System.Windows.Forms.Label LostPacketsTooltipLabel;
        private System.Windows.Forms.Label LatencyLabel;
        private System.Windows.Forms.Label LatencyTooltipLabel;
        private NAudio.Gui.VolumeSlider MicrophoneVolumeSlider;
        private NAudio.Gui.VolumeSlider SpeakersVolumeSlider;
    }
}