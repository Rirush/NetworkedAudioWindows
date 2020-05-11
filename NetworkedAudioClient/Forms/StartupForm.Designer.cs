namespace NetworkedAudioClient.Forms
{
    partial class StartupForm
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
            this.AudioSettingsGroup = new System.Windows.Forms.GroupBox();
            this.BitrateUpDown = new System.Windows.Forms.NumericUpDown();
            this.MuteAudioCheckBox = new System.Windows.Forms.CheckBox();
            this.BitrateLabel = new System.Windows.Forms.Label();
            this.RefreshDevicesButton = new System.Windows.Forms.Button();
            this.OutputDevicesComboBox = new System.Windows.Forms.ComboBox();
            this.InputDevicesComboBox = new System.Windows.Forms.ComboBox();
            this.OutputInterfaceLabel = new System.Windows.Forms.Label();
            this.InputInterfaceLabel = new System.Windows.Forms.Label();
            this.NetworkGroupBox = new System.Windows.Forms.GroupBox();
            this.NicknameTextBox = new System.Windows.Forms.TextBox();
            this.NicknameLabel = new System.Windows.Forms.Label();
            this.ManualDeviceEntryButton = new System.Windows.Forms.Button();
            this.DeviceDetailsButton = new System.Windows.Forms.Button();
            this.RediscoverNetworkDevices = new System.Windows.Forms.Button();
            this.DiscoveredDevicesLabel = new System.Windows.Forms.Label();
            this.DiscoveredDevices = new System.Windows.Forms.ListBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.DiscoveryWorker = new System.ComponentModel.BackgroundWorker();
            this.AudioSettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitrateUpDown)).BeginInit();
            this.NetworkGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AudioSettingsGroup
            // 
            this.AudioSettingsGroup.Controls.Add(this.BitrateUpDown);
            this.AudioSettingsGroup.Controls.Add(this.MuteAudioCheckBox);
            this.AudioSettingsGroup.Controls.Add(this.BitrateLabel);
            this.AudioSettingsGroup.Controls.Add(this.RefreshDevicesButton);
            this.AudioSettingsGroup.Controls.Add(this.OutputDevicesComboBox);
            this.AudioSettingsGroup.Controls.Add(this.InputDevicesComboBox);
            this.AudioSettingsGroup.Controls.Add(this.OutputInterfaceLabel);
            this.AudioSettingsGroup.Controls.Add(this.InputInterfaceLabel);
            this.AudioSettingsGroup.Location = new System.Drawing.Point(12, 12);
            this.AudioSettingsGroup.Name = "AudioSettingsGroup";
            this.AudioSettingsGroup.Size = new System.Drawing.Size(265, 127);
            this.AudioSettingsGroup.TabIndex = 0;
            this.AudioSettingsGroup.TabStop = false;
            this.AudioSettingsGroup.Text = "Audio Settings";
            // 
            // BitrateUpDown
            // 
            this.BitrateUpDown.Location = new System.Drawing.Point(136, 74);
            this.BitrateUpDown.Maximum = new decimal(new int[] {
            510,
            0,
            0,
            0});
            this.BitrateUpDown.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.BitrateUpDown.Name = "BitrateUpDown";
            this.BitrateUpDown.Size = new System.Drawing.Size(121, 20);
            this.BitrateUpDown.TabIndex = 7;
            this.BitrateUpDown.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // MuteAudioCheckBox
            // 
            this.MuteAudioCheckBox.AutoSize = true;
            this.MuteAudioCheckBox.Location = new System.Drawing.Point(9, 100);
            this.MuteAudioCheckBox.Name = "MuteAudioCheckBox";
            this.MuteAudioCheckBox.Size = new System.Drawing.Size(96, 17);
            this.MuteAudioCheckBox.TabIndex = 6;
            this.MuteAudioCheckBox.Text = "Mute speakers";
            this.MuteAudioCheckBox.UseVisualStyleBackColor = true;
            // 
            // BitrateLabel
            // 
            this.BitrateLabel.AutoSize = true;
            this.BitrateLabel.Location = new System.Drawing.Point(135, 56);
            this.BitrateLabel.Name = "BitrateLabel";
            this.BitrateLabel.Size = new System.Drawing.Size(40, 13);
            this.BitrateLabel.TabIndex = 4;
            this.BitrateLabel.Text = "Bitrate:";
            // 
            // RefreshDevicesButton
            // 
            this.RefreshDevicesButton.Location = new System.Drawing.Point(9, 71);
            this.RefreshDevicesButton.Name = "RefreshDevicesButton";
            this.RefreshDevicesButton.Size = new System.Drawing.Size(121, 23);
            this.RefreshDevicesButton.TabIndex = 3;
            this.RefreshDevicesButton.Text = "Refresh";
            this.RefreshDevicesButton.UseVisualStyleBackColor = true;
            this.RefreshDevicesButton.Click += new System.EventHandler(this.RefreshDevicesButton_Click);
            // 
            // OutputDevicesComboBox
            // 
            this.OutputDevicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputDevicesComboBox.FormattingEnabled = true;
            this.OutputDevicesComboBox.Location = new System.Drawing.Point(136, 32);
            this.OutputDevicesComboBox.Name = "OutputDevicesComboBox";
            this.OutputDevicesComboBox.Size = new System.Drawing.Size(121, 21);
            this.OutputDevicesComboBox.TabIndex = 2;
            // 
            // InputDevicesComboBox
            // 
            this.InputDevicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InputDevicesComboBox.FormattingEnabled = true;
            this.InputDevicesComboBox.Location = new System.Drawing.Point(9, 32);
            this.InputDevicesComboBox.Name = "InputDevicesComboBox";
            this.InputDevicesComboBox.Size = new System.Drawing.Size(121, 21);
            this.InputDevicesComboBox.TabIndex = 1;
            // 
            // OutputInterfaceLabel
            // 
            this.OutputInterfaceLabel.AutoSize = true;
            this.OutputInterfaceLabel.Location = new System.Drawing.Point(133, 16);
            this.OutputInterfaceLabel.Name = "OutputInterfaceLabel";
            this.OutputInterfaceLabel.Size = new System.Drawing.Size(42, 13);
            this.OutputInterfaceLabel.TabIndex = 1;
            this.OutputInterfaceLabel.Text = "Output:";
            // 
            // InputInterfaceLabel
            // 
            this.InputInterfaceLabel.AutoSize = true;
            this.InputInterfaceLabel.Location = new System.Drawing.Point(6, 16);
            this.InputInterfaceLabel.Name = "InputInterfaceLabel";
            this.InputInterfaceLabel.Size = new System.Drawing.Size(34, 13);
            this.InputInterfaceLabel.TabIndex = 0;
            this.InputInterfaceLabel.Text = "Input:";
            // 
            // NetworkGroupBox
            // 
            this.NetworkGroupBox.Controls.Add(this.NicknameTextBox);
            this.NetworkGroupBox.Controls.Add(this.NicknameLabel);
            this.NetworkGroupBox.Controls.Add(this.ManualDeviceEntryButton);
            this.NetworkGroupBox.Controls.Add(this.DeviceDetailsButton);
            this.NetworkGroupBox.Controls.Add(this.RediscoverNetworkDevices);
            this.NetworkGroupBox.Controls.Add(this.DiscoveredDevicesLabel);
            this.NetworkGroupBox.Controls.Add(this.DiscoveredDevices);
            this.NetworkGroupBox.Location = new System.Drawing.Point(12, 145);
            this.NetworkGroupBox.Name = "NetworkGroupBox";
            this.NetworkGroupBox.Size = new System.Drawing.Size(265, 200);
            this.NetworkGroupBox.TabIndex = 1;
            this.NetworkGroupBox.TabStop = false;
            this.NetworkGroupBox.Text = "Network Settings";
            // 
            // NicknameTextBox
            // 
            this.NicknameTextBox.Location = new System.Drawing.Point(6, 172);
            this.NicknameTextBox.MaxLength = 100;
            this.NicknameTextBox.Name = "NicknameTextBox";
            this.NicknameTextBox.Size = new System.Drawing.Size(250, 20);
            this.NicknameTextBox.TabIndex = 6;
            this.NicknameTextBox.Text = "Computer";
            // 
            // NicknameLabel
            // 
            this.NicknameLabel.AutoSize = true;
            this.NicknameLabel.Location = new System.Drawing.Point(5, 156);
            this.NicknameLabel.Name = "NicknameLabel";
            this.NicknameLabel.Size = new System.Drawing.Size(58, 13);
            this.NicknameLabel.TabIndex = 5;
            this.NicknameLabel.Text = "Nickname:";
            // 
            // ManualDeviceEntryButton
            // 
            this.ManualDeviceEntryButton.Location = new System.Drawing.Point(132, 74);
            this.ManualDeviceEntryButton.Name = "ManualDeviceEntryButton";
            this.ManualDeviceEntryButton.Size = new System.Drawing.Size(124, 23);
            this.ManualDeviceEntryButton.TabIndex = 4;
            this.ManualDeviceEntryButton.Text = "Manual entry";
            this.ManualDeviceEntryButton.UseVisualStyleBackColor = true;
            // 
            // DeviceDetailsButton
            // 
            this.DeviceDetailsButton.Location = new System.Drawing.Point(132, 45);
            this.DeviceDetailsButton.Name = "DeviceDetailsButton";
            this.DeviceDetailsButton.Size = new System.Drawing.Size(124, 23);
            this.DeviceDetailsButton.TabIndex = 3;
            this.DeviceDetailsButton.Text = "Details";
            this.DeviceDetailsButton.UseVisualStyleBackColor = true;
            // 
            // RediscoverNetworkDevices
            // 
            this.RediscoverNetworkDevices.Location = new System.Drawing.Point(132, 16);
            this.RediscoverNetworkDevices.Name = "RediscoverNetworkDevices";
            this.RediscoverNetworkDevices.Size = new System.Drawing.Size(124, 23);
            this.RediscoverNetworkDevices.TabIndex = 2;
            this.RediscoverNetworkDevices.Text = "Refresh";
            this.RediscoverNetworkDevices.UseVisualStyleBackColor = true;
            this.RediscoverNetworkDevices.Click += new System.EventHandler(this.RediscoverNetworkDevices_Click);
            // 
            // DiscoveredDevicesLabel
            // 
            this.DiscoveredDevicesLabel.AutoSize = true;
            this.DiscoveredDevicesLabel.Location = new System.Drawing.Point(6, 16);
            this.DiscoveredDevicesLabel.Name = "DiscoveredDevicesLabel";
            this.DiscoveredDevicesLabel.Size = new System.Drawing.Size(104, 13);
            this.DiscoveredDevicesLabel.TabIndex = 1;
            this.DiscoveredDevicesLabel.Text = "Discovered devices:";
            // 
            // DiscoveredDevices
            // 
            this.DiscoveredDevices.FormattingEnabled = true;
            this.DiscoveredDevices.Location = new System.Drawing.Point(6, 32);
            this.DiscoveredDevices.Name = "DiscoveredDevices";
            this.DiscoveredDevices.Size = new System.Drawing.Size(120, 121);
            this.DiscoveredDevices.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(13, 351);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(264, 23);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // DiscoveryWorker
            // 
            this.DiscoveryWorker.WorkerReportsProgress = true;
            this.DiscoveryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DiscoveryWorker_DoWork);
            this.DiscoveryWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DiscoveryWorker_ProgressChanged);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 382);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.NetworkGroupBox);
            this.Controls.Add(this.AudioSettingsGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Networked Audio Client";
            this.AudioSettingsGroup.ResumeLayout(false);
            this.AudioSettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BitrateUpDown)).EndInit();
            this.NetworkGroupBox.ResumeLayout(false);
            this.NetworkGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AudioSettingsGroup;
        private System.Windows.Forms.Label BitrateLabel;
        private System.Windows.Forms.Button RefreshDevicesButton;
        private System.Windows.Forms.ComboBox OutputDevicesComboBox;
        private System.Windows.Forms.ComboBox InputDevicesComboBox;
        private System.Windows.Forms.Label OutputInterfaceLabel;
        private System.Windows.Forms.Label InputInterfaceLabel;
        private System.Windows.Forms.GroupBox NetworkGroupBox;
        private System.Windows.Forms.Button DeviceDetailsButton;
        private System.Windows.Forms.Button RediscoverNetworkDevices;
        private System.Windows.Forms.Label DiscoveredDevicesLabel;
        private System.Windows.Forms.ListBox DiscoveredDevices;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ManualDeviceEntryButton;
        private System.Windows.Forms.CheckBox MuteAudioCheckBox;
        private System.Windows.Forms.NumericUpDown BitrateUpDown;
        private System.Windows.Forms.TextBox NicknameTextBox;
        private System.Windows.Forms.Label NicknameLabel;
        private System.ComponentModel.BackgroundWorker DiscoveryWorker;
    }
}

