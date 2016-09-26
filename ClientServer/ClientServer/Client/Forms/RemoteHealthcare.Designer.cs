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
            this.connectStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataBox = new System.Windows.Forms.GroupBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.buttonsBox = new System.Windows.Forms.GroupBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.chatTextBox = new System.Windows.Forms.RichTextBox();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.statusBar.SuspendLayout();
            this.dataBox.SuspendLayout();
            this.buttonsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usernameLabel,
            this.connectStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 0);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(832, 25);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusBar";
            // 
            // usernameLabel
            // 
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(109, 20);
            this.usernameLabel.Text = "usernameLabel";
            // 
            // connectStatusLabel
            // 
            this.connectStatusLabel.Margin = new System.Windows.Forms.Padding(435, 3, 0, 2);
            this.connectStatusLabel.Name = "connectStatusLabel";
            this.connectStatusLabel.Size = new System.Drawing.Size(107, 20);
            this.connectStatusLabel.Text = "Not connected";
            // 
            // dataBox
            // 
            this.dataBox.BackColor = System.Drawing.Color.White;
            this.dataBox.Controls.Add(this.infoLabel);
            this.dataBox.Location = new System.Drawing.Point(16, 31);
            this.dataBox.Margin = new System.Windows.Forms.Padding(4);
            this.dataBox.Name = "dataBox";
            this.dataBox.Padding = new System.Windows.Forms.Padding(4);
            this.dataBox.Size = new System.Drawing.Size(260, 399);
            this.dataBox.TabIndex = 1;
            this.dataBox.TabStop = false;
            this.dataBox.Text = "Data";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(8, 20);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(58, 17);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "No data";
            // 
            // buttonsBox
            // 
            this.buttonsBox.Controls.Add(this.messageTextBox);
            this.buttonsBox.Controls.Add(this.sendButton);
            this.buttonsBox.Controls.Add(this.chatTextBox);
            this.buttonsBox.Controls.Add(this.disconnectButton);
            this.buttonsBox.Location = new System.Drawing.Point(284, 31);
            this.buttonsBox.Margin = new System.Windows.Forms.Padding(4);
            this.buttonsBox.Name = "buttonsBox";
            this.buttonsBox.Padding = new System.Windows.Forms.Padding(4);
            this.buttonsBox.Size = new System.Drawing.Size(532, 399);
            this.buttonsBox.TabIndex = 2;
            this.buttonsBox.TabStop = false;
            this.buttonsBox.Text = "Chat";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(8, 301);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(422, 22);
            this.messageTextBox.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sendButton.Location = new System.Drawing.Point(436, 300);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(89, 23);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(8, 23);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(517, 272);
            this.chatTextBox.TabIndex = 1;
            this.chatTextBox.Text = "";
            // 
            // disconnectButton
            // 
            this.disconnectButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.disconnectButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.disconnectButton.Location = new System.Drawing.Point(424, 363);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(100, 28);
            this.disconnectButton.TabIndex = 0;
            this.disconnectButton.Text = "Uitloggen";
            this.disconnectButton.UseVisualStyleBackColor = false;
            // 
            // RemoteHealthcare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(832, 444);
            this.Controls.Add(this.buttonsBox);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RemoteHealthcare";
            this.Text = "RemoteHealthcare";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RemoteHealthcare_Paint);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.dataBox.ResumeLayout(false);
            this.dataBox.PerformLayout();
            this.buttonsBox.ResumeLayout(false);
            this.buttonsBox.PerformLayout();
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
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.RichTextBox chatTextBox;
    }
}