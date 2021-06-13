
namespace ESP32BLEServer
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupAddr = new System.Windows.Forms.GroupBox();
            this.bleAddress = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupCommandTemplate = new System.Windows.Forms.GroupBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.groupDataSource = new System.Windows.Forms.GroupBox();
            this.chkBtcUsd = new System.Windows.Forms.CheckBox();
            this.chkEthUsd = new System.Windows.Forms.CheckBox();
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.chkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupAddr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bleAddress)).BeginInit();
            this.groupCommandTemplate.SuspendLayout();
            this.groupDataSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(416, 352);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(128, 46);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupAddr
            // 
            this.groupAddr.Controls.Add(this.bleAddress);
            this.groupAddr.Controls.Add(this.label1);
            this.groupAddr.Location = new System.Drawing.Point(16, 16);
            this.groupAddr.Name = "groupAddr";
            this.groupAddr.Size = new System.Drawing.Size(528, 112);
            this.groupAddr.TabIndex = 5;
            this.groupAddr.TabStop = false;
            this.groupAddr.Text = "Device";
            // 
            // bleAddress
            // 
            this.bleAddress.Location = new System.Drawing.Point(255, 50);
            this.bleAddress.Maximum = new decimal(new int[] {
            -1,
            65535,
            0,
            0});
            this.bleAddress.Name = "bleAddress";
            this.bleAddress.Size = new System.Drawing.Size(257, 38);
            this.bleAddress.TabIndex = 5;
            this.bleAddress.Value = new decimal(new int[] {
            1615790050,
            9377,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "BLE Device Address:";
            // 
            // groupCommandTemplate
            // 
            this.groupCommandTemplate.Controls.Add(this.txtCommand);
            this.groupCommandTemplate.Location = new System.Drawing.Point(560, 16);
            this.groupCommandTemplate.Name = "groupCommandTemplate";
            this.groupCommandTemplate.Size = new System.Drawing.Size(608, 384);
            this.groupCommandTemplate.TabIndex = 6;
            this.groupCommandTemplate.TabStop = false;
            this.groupCommandTemplate.Text = "Command Template";
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCommand.Location = new System.Drawing.Point(16, 48);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(576, 320);
            this.txtCommand.TabIndex = 7;
            this.txtCommand.Text = resources.GetString("txtCommand.Text");
            // 
            // groupDataSource
            // 
            this.groupDataSource.Controls.Add(this.chkBtcUsd);
            this.groupDataSource.Controls.Add(this.chkEthUsd);
            this.groupDataSource.Controls.Add(this.chkTime);
            this.groupDataSource.Location = new System.Drawing.Point(16, 144);
            this.groupDataSource.Name = "groupDataSource";
            this.groupDataSource.Size = new System.Drawing.Size(528, 192);
            this.groupDataSource.TabIndex = 7;
            this.groupDataSource.TabStop = false;
            this.groupDataSource.Text = "Data Sources";
            // 
            // chkBtcUsd
            // 
            this.chkBtcUsd.AutoSize = true;
            this.chkBtcUsd.Checked = true;
            this.chkBtcUsd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBtcUsd.Location = new System.Drawing.Point(16, 96);
            this.chkBtcUsd.Name = "chkBtcUsd";
            this.chkBtcUsd.Size = new System.Drawing.Size(450, 35);
            this.chkBtcUsd.TabIndex = 2;
            this.chkBtcUsd.Text = "CryptoCurrency BTC to USD (@btc)";
            this.chkBtcUsd.UseVisualStyleBackColor = true;
            // 
            // chkEthUsd
            // 
            this.chkEthUsd.AutoSize = true;
            this.chkEthUsd.Checked = true;
            this.chkEthUsd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEthUsd.Location = new System.Drawing.Point(16, 144);
            this.chkEthUsd.Name = "chkEthUsd";
            this.chkEthUsd.Size = new System.Drawing.Size(453, 35);
            this.chkEthUsd.TabIndex = 1;
            this.chkEthUsd.Text = "CryptoCurrency ETH to USD (@eth)";
            this.chkEthUsd.UseVisualStyleBackColor = true;
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.Checked = true;
            this.chkTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTime.Location = new System.Drawing.Point(16, 48);
            this.chkTime.Name = "chkTime";
            this.chkTime.Size = new System.Drawing.Size(396, 35);
            this.chkTime.TabIndex = 0;
            this.chkTime.Text = "Current Time (@time, HH:mm)";
            this.chkTime.UseVisualStyleBackColor = true;
            // 
            // chkAutoUpdate
            // 
            this.chkAutoUpdate.AutoSize = true;
            this.chkAutoUpdate.Location = new System.Drawing.Point(32, 359);
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.Size = new System.Drawing.Size(331, 35);
            this.chkAutoUpdate.TabIndex = 8;
            this.chkAutoUpdate.Text = "Enable automatic update";
            this.chkAutoUpdate.UseVisualStyleBackColor = true;
            this.chkAutoUpdate.CheckedChanged += new System.EventHandler(this.chkAutoUpdate_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ESP32 BLE Server";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 414);
            this.Controls.Add(this.chkAutoUpdate);
            this.Controls.Add(this.groupDataSource);
            this.Controls.Add(this.groupCommandTemplate);
            this.Controls.Add(this.groupAddr);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.Text = "ESP32 BLE Server";
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.groupAddr.ResumeLayout(false);
            this.groupAddr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bleAddress)).EndInit();
            this.groupCommandTemplate.ResumeLayout(false);
            this.groupCommandTemplate.PerformLayout();
            this.groupDataSource.ResumeLayout(false);
            this.groupDataSource.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupAddr;
        private System.Windows.Forms.NumericUpDown bleAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupCommandTemplate;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.GroupBox groupDataSource;
        private System.Windows.Forms.CheckBox chkAutoUpdate;
        private System.Windows.Forms.CheckBox chkTime;
        private System.Windows.Forms.CheckBox chkBtcUsd;
        private System.Windows.Forms.CheckBox chkEthUsd;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

