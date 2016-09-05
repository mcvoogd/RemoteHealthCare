namespace Simulation
{
    partial class DataWindow
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
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataTextBox = new System.Windows.Forms.RichTextBox();
            this.controlPanelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 42);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(122, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(13, 71);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(121, 23);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataTextBox
            // 
            this.dataTextBox.Location = new System.Drawing.Point(140, 12);
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.ReadOnly = true;
            this.dataTextBox.Size = new System.Drawing.Size(842, 229);
            this.dataTextBox.TabIndex = 3;
            this.dataTextBox.Text = "";
            // 
            // controlPanelButton
            // 
            this.controlPanelButton.Location = new System.Drawing.Point(12, 101);
            this.controlPanelButton.Name = "controlPanelButton";
            this.controlPanelButton.Size = new System.Drawing.Size(122, 23);
            this.controlPanelButton.TabIndex = 4;
            this.controlPanelButton.Text = "controle paneel";
            this.controlPanelButton.UseVisualStyleBackColor = true;
            this.controlPanelButton.Click += new System.EventHandler(this.controlPanelButton_Click);
            // 
            // DataWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 253);
            this.Controls.Add(this.controlPanelButton);
            this.Controls.Add(this.dataTextBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Name = "DataWindow";
            this.Text = "DataWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.RichTextBox dataTextBox;
        private System.Windows.Forms.Button controlPanelButton;
    }
}