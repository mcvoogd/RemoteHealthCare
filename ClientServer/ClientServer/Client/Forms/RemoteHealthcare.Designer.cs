namespace Client.Forms
{
    partial class RemoteHealthcare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteHealthcare));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.usernameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataBox = new System.Windows.Forms.GroupBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.buttonsBox = new System.Windows.Forms.GroupBox();
            this.connectStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.sendMeasurementButton = new System.Windows.Forms.Button();
            this.statusBar.SuspendLayout();
            this.dataBox.SuspendLayout();
            this.buttonsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usernameLabel,
            this.connectStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 0);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(624, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusBar";
            // 
            // usernameLabel
            // 
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(87, 17);
            this.usernameLabel.Text = "usernameLabel";
            // 
            // dataBox
            // 
            this.dataBox.BackColor = System.Drawing.Color.White;
            this.dataBox.Controls.Add(this.infoLabel);
            this.dataBox.Location = new System.Drawing.Point(12, 25);
            this.dataBox.Name = "dataBox";
            this.dataBox.Size = new System.Drawing.Size(195, 324);
            this.dataBox.TabIndex = 1;
            this.dataBox.TabStop = false;
            this.dataBox.Text = "Data";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(6, 16);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(45, 13);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "No data";
            // 
            // buttonsBox
            // 
            this.buttonsBox.Controls.Add(this.sendMeasurementButton);
            this.buttonsBox.Controls.Add(this.disconnectButton);
            this.buttonsBox.Location = new System.Drawing.Point(213, 25);
            this.buttonsBox.Name = "buttonsBox";
            this.buttonsBox.Size = new System.Drawing.Size(399, 324);
            this.buttonsBox.TabIndex = 2;
            this.buttonsBox.TabStop = false;
            this.buttonsBox.Text = "Buttons";
            // 
            // connectStatusLabel
            // 
            this.connectStatusLabel.Margin = new System.Windows.Forms.Padding(435, 3, 0, 2);
            this.connectStatusLabel.Name = "connectStatusLabel";
            this.connectStatusLabel.Size = new System.Drawing.Size(86, 17);
            this.connectStatusLabel.Text = "Not connected";
            // 
            // disconnectButton
            // 
            this.disconnectButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.disconnectButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.disconnectButton.Location = new System.Drawing.Point(318, 295);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 0;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = false;
            // 
            // sendMeasurementButton
            // 
            this.sendMeasurementButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sendMeasurementButton.Location = new System.Drawing.Point(6, 19);
            this.sendMeasurementButton.Name = "sendMeasurementButton";
            this.sendMeasurementButton.Size = new System.Drawing.Size(108, 36);
            this.sendMeasurementButton.TabIndex = 1;
            this.sendMeasurementButton.Text = "Send Measurement";
            this.sendMeasurementButton.UseVisualStyleBackColor = false;
            // 
            // RemoteHealthcare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 361);
            this.Controls.Add(this.buttonsBox);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemoteHealthcare";
            this.Text = "RemoteHealthcare";
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.dataBox.ResumeLayout(false);
            this.dataBox.PerformLayout();
            this.buttonsBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel usernameLabel;
        private System.Windows.Forms.GroupBox dataBox;
        private System.Windows.Forms.ToolStripStatusLabel connectStatusLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.GroupBox buttonsBox;
        private System.Windows.Forms.Button sendMeasurementButton;
        private System.Windows.Forms.Button disconnectButton;
    }
}