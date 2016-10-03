﻿namespace Client.Forms
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteHealthcare));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.usernameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonsBox = new System.Windows.Forms.GroupBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.chatTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comPortConnectButton = new System.Windows.Forms.Button();
            this.comportBox = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statusBar.SuspendLayout();
            this.buttonsBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            this.statusBar.Padding = new System.Windows.Forms.Padding(2, 0, 38, 0);
            this.statusBar.Size = new System.Drawing.Size(1664, 46);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusBar";
            // 
            // usernameLabel
            // 
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(218, 41);
            this.usernameLabel.Text = "usernameLabel";
            // 
            // connectStatusLabel
            // 
            this.connectStatusLabel.Margin = new System.Windows.Forms.Padding(435, 3, 0, 2);
            this.connectStatusLabel.Name = "connectStatusLabel";
            this.connectStatusLabel.Size = new System.Drawing.Size(216, 41);
            this.connectStatusLabel.Text = "Not connected";
            // 
            // buttonsBox
            // 
            this.buttonsBox.Controls.Add(this.messageTextBox);
            this.buttonsBox.Controls.Add(this.sendButton);
            this.buttonsBox.Controls.Add(this.chatTextBox);
            this.buttonsBox.Location = new System.Drawing.Point(568, 60);
            this.buttonsBox.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.buttonsBox.Name = "buttonsBox";
            this.buttonsBox.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.buttonsBox.Size = new System.Drawing.Size(1064, 773);
            this.buttonsBox.TabIndex = 2;
            this.buttonsBox.TabStop = false;
            this.buttonsBox.Text = "Chat";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(14, 705);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(816, 38);
            this.messageTextBox.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sendButton.Location = new System.Drawing.Point(842, 701);
            this.sendButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(202, 45);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(14, 45);
            this.chatTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.ReadOnly = true;
            this.chatTextBox.Size = new System.Drawing.Size(1030, 641);
            this.chatTextBox.TabIndex = 1;
            this.chatTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.comPortConnectButton);
            this.groupBox1.Controls.Add(this.comportBox);
            this.groupBox1.Location = new System.Drawing.Point(26, 60);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(542, 176);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "fiets connectie";
            // 
            // comPortConnectButton
            // 
            this.comPortConnectButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.comPortConnectButton.Location = new System.Drawing.Point(322, 40);
            this.comPortConnectButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comPortConnectButton.Name = "comPortConnectButton";
            this.comPortConnectButton.Size = new System.Drawing.Size(180, 46);
            this.comPortConnectButton.TabIndex = 1;
            this.comPortConnectButton.Text = "Connect";
            this.comPortConnectButton.UseVisualStyleBackColor = false;
            this.comPortConnectButton.Click += new System.EventHandler(this.comPortConnectButton_Click);
            // 
            // comportBox
            // 
            this.comportBox.FormattingEnabled = true;
            this.comportBox.Location = new System.Drawing.Point(16, 45);
            this.comportBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comportBox.Name = "comportBox";
            this.comportBox.Size = new System.Drawing.Size(294, 39);
            this.comportBox.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 93F;
            chartArea1.Position.Width = 94F;
            chartArea1.Position.Y = 7F;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 7F;
            legend1.Position.Width = 35F;
            legend1.Position.X = 15F;
            legend1.Position.Y = 1F;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(26, 247);
            this.chart1.Name = "chart1";
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(531, 573);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "BicycleChart";
            // 
            // RemoteHealthcare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1664, 860);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonsBox);
            this.Controls.Add(this.statusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Name = "RemoteHealthcare";
            this.Text = "RemoteHealthcare";
            this.Load += new System.EventHandler(this.RemoteHealthcare_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RemoteHealthcare_Paint);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.buttonsBox.ResumeLayout(false);
            this.buttonsBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel usernameLabel;
        private System.Windows.Forms.ToolStripStatusLabel connectStatusLabel;
        private System.Windows.Forms.GroupBox buttonsBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.RichTextBox chatTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button comPortConnectButton;
        private System.Windows.Forms.ComboBox comportBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}