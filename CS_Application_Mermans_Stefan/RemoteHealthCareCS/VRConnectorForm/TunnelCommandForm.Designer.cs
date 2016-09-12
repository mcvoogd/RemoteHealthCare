namespace VRConnectorForm
{
    partial class TunnelCommandForm
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
            this.sedCommandButton = new System.Windows.Forms.Button();
            this.TunnelId = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.StatisticsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sedCommandButton
            // 
            this.sedCommandButton.Location = new System.Drawing.Point(24, 114);
            this.sedCommandButton.Margin = new System.Windows.Forms.Padding(6);
            this.sedCommandButton.Name = "sedCommandButton";
            this.sedCommandButton.Size = new System.Drawing.Size(248, 45);
            this.sedCommandButton.TabIndex = 1;
            this.sedCommandButton.Text = "SendCommand";
            this.sedCommandButton.UseVisualStyleBackColor = true;
            this.sedCommandButton.Click += new System.EventHandler(this.sedCommandButton_Click);
            // 
            // TunnelId
            // 
            this.TunnelId.AutoSize = true;
            this.TunnelId.Location = new System.Drawing.Point(922, 66);
            this.TunnelId.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TunnelId.Name = "TunnelId";
            this.TunnelId.Size = new System.Drawing.Size(0, 32);
            this.TunnelId.TabIndex = 2;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(928, 126);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(93, 32);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "label1";
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.Location = new System.Drawing.Point(24, 50);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(248, 48);
            this.StatisticsButton.TabIndex = 4;
            this.StatisticsButton.Text = "View Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = true;
            this.StatisticsButton.Click += new System.EventHandler(this.StatisticsButton_Click_1);
            // 
            // TunnelCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 860);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.TunnelId);
            this.Controls.Add(this.sedCommandButton);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TunnelCommandForm";
            this.Text = "TunnelCommandForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sedCommandButton;
        private System.Windows.Forms.Label TunnelId;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button StatisticsButton;
    }
}