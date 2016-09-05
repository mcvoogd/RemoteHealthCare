namespace RemoteHealthCareCS
{
    partial class Form1
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
            this.resetButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.IDButton = new System.Windows.Forms.Button();
            this.versionButton = new System.Windows.Forms.Button();
            this.commandMButton = new System.Windows.Forms.Button();
            this.statusButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.Location = new System.Drawing.Point(367, 13);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(121, 23);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 42);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(121, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // IDButton
            // 
            this.IDButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IDButton.Location = new System.Drawing.Point(367, 42);
            this.IDButton.Name = "IDButton";
            this.IDButton.Size = new System.Drawing.Size(121, 23);
            this.IDButton.TabIndex = 3;
            this.IDButton.Text = "ID";
            this.IDButton.UseVisualStyleBackColor = true;
            this.IDButton.Click += new System.EventHandler(this.IDButton_Click);
            // 
            // versionButton
            // 
            this.versionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.versionButton.Location = new System.Drawing.Point(367, 72);
            this.versionButton.Name = "versionButton";
            this.versionButton.Size = new System.Drawing.Size(121, 23);
            this.versionButton.TabIndex = 4;
            this.versionButton.Text = "version";
            this.versionButton.UseVisualStyleBackColor = true;
            this.versionButton.Click += new System.EventHandler(this.versionButton_Click);
            // 
            // commandMButton
            // 
            this.commandMButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.commandMButton.Location = new System.Drawing.Point(367, 102);
            this.commandMButton.Name = "commandMButton";
            this.commandMButton.Size = new System.Drawing.Size(121, 23);
            this.commandMButton.TabIndex = 5;
            this.commandMButton.Text = "Command mode";
            this.commandMButton.UseVisualStyleBackColor = true;
            this.commandMButton.Click += new System.EventHandler(this.commandMButton_Click);
            // 
            // statusButton
            // 
            this.statusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statusButton.Location = new System.Drawing.Point(367, 131);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(121, 23);
            this.statusButton.TabIndex = 6;
            this.statusButton.Text = "Status";
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(13, 72);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(120, 23);
            this.disconnectButton.TabIndex = 7;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 112);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 178);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.statusButton);
            this.Controls.Add(this.commandMButton);
            this.Controls.Add(this.versionButton);
            this.Controls.Add(this.IDButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.resetButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button IDButton;
        private System.Windows.Forms.Button versionButton;
        private System.Windows.Forms.Button commandMButton;
        private System.Windows.Forms.Button statusButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}

