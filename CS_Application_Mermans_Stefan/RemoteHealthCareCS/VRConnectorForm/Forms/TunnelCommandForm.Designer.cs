using System.Windows.Forms;

namespace VRConnectorForm.Forms
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
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.CreateAuto = new System.Windows.Forms.Button();
            this.SendAuto = new System.Windows.Forms.Button();
            this.MoveCar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sedCommandButton
            // 
            this.sedCommandButton.Location = new System.Drawing.Point(24, 114);
            this.sedCommandButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.sedCommandButton.Name = "sedCommandButton";
            this.sedCommandButton.Size = new System.Drawing.Size(256, 48);
            this.sedCommandButton.TabIndex = 1;
            this.sedCommandButton.Text = "SendCommand";
            this.sedCommandButton.UseVisualStyleBackColor = true;
            this.sedCommandButton.Click += new System.EventHandler(this.sedCommandButton_Click);
            // 
            // TunnelId
            // 
            this.TunnelId.AutoSize = true;
            this.TunnelId.Location = new System.Drawing.Point(747, 67);
            this.TunnelId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TunnelId.Name = "TunnelId";
            this.TunnelId.Size = new System.Drawing.Size(0, 32);
            this.TunnelId.TabIndex = 2;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(747, 129);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(0, 32);
            this.NameLabel.TabIndex = 3;
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.Location = new System.Drawing.Point(24, 50);
            this.StatisticsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(256, 48);
            this.StatisticsButton.TabIndex = 4;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = true;
            this.StatisticsButton.Click += new System.EventHandler(this.StatisticsButton_Click_1);
            // 
            // CreateAuto
            // 
            this.CreateAuto.Location = new System.Drawing.Point(24, 176);
            this.CreateAuto.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.CreateAuto.Name = "CreateAuto";
            this.CreateAuto.Size = new System.Drawing.Size(256, 48);
            this.CreateAuto.TabIndex = 5;
            this.CreateAuto.Text = "Create Auto";
            this.CreateAuto.UseVisualStyleBackColor = true;
            this.CreateAuto.Click += new System.EventHandler(this.CreateAuto_Click);
            // 
            // SendAuto
            // 
            this.SendAuto.Location = new System.Drawing.Point(24, 238);
            this.SendAuto.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.SendAuto.Name = "SendAuto";
            this.SendAuto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SendAuto.Size = new System.Drawing.Size(256, 48);
            this.SendAuto.TabIndex = 6;
            this.SendAuto.Text = "Send Auto";
            this.SendAuto.UseVisualStyleBackColor = true;
            this.SendAuto.Click += new System.EventHandler(this.SendAuto_Click);
            // 
            // MoveCar
            // 
            this.MoveCar.Location = new System.Drawing.Point(24, 315);
            this.MoveCar.Name = "MoveCar";
            this.MoveCar.Size = new System.Drawing.Size(256, 43);
            this.MoveCar.TabIndex = 7;
            this.MoveCar.Text = "Move Car";
            this.MoveCar.UseVisualStyleBackColor = true;
            this.MoveCar.Click += new System.EventHandler(this.MoveCar_Click);
            // 
            // TunnelCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 861);
            this.Controls.Add(this.MoveCar);
            this.Controls.Add(this.SendAuto);
            this.Controls.Add(this.CreateAuto);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.TunnelId);
            this.Controls.Add(this.sedCommandButton);
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
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
        private Button CreateAuto;
        private Button SendAuto;
        private Button MoveCar;
    }
}