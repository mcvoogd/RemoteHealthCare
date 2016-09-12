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
            this.SuspendLayout();
            // 
            // sedCommandButton
            // 
            this.sedCommandButton.Location = new System.Drawing.Point(12, 59);
            this.sedCommandButton.Name = "sedCommandButton";
            this.sedCommandButton.Size = new System.Drawing.Size(124, 23);
            this.sedCommandButton.TabIndex = 1;
            this.sedCommandButton.Text = "SendCommand";
            this.sedCommandButton.UseVisualStyleBackColor = true;
            this.sedCommandButton.Click += new System.EventHandler(this.sedCommandButton_Click);
            // 
            // TunnelId
            // 
            this.TunnelId.AutoSize = true;
            this.TunnelId.Location = new System.Drawing.Point(9, 9);
            this.TunnelId.Name = "TunnelId";
            this.TunnelId.Size = new System.Drawing.Size(46, 17);
            this.TunnelId.TabIndex = 2;
            this.TunnelId.Text = "label1";
            // 
            // TunnelCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 444);
            this.Controls.Add(this.TunnelId);
            this.Controls.Add(this.sedCommandButton);
            this.Name = "TunnelCommandForm";
            this.Text = "TunnelCommandForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sedCommandButton;
        private System.Windows.Forms.Label TunnelId;
    }
}