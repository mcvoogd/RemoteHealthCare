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
            this.button1 = new System.Windows.Forms.Button();
            this.GetScene = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.addTerrainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sedCommandButton
            // 
            this.sedCommandButton.Location = new System.Drawing.Point(12, 59);
            this.sedCommandButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.sedCommandButton.Name = "sedCommandButton";
            this.sedCommandButton.Size = new System.Drawing.Size(128, 25);
            this.sedCommandButton.TabIndex = 1;
            this.sedCommandButton.Text = "SendCommand";
            this.sedCommandButton.UseVisualStyleBackColor = true;
            this.sedCommandButton.Click += new System.EventHandler(this.sedCommandButton_Click);
            // 
            // TunnelId
            // 
            this.TunnelId.AutoSize = true;
            this.TunnelId.Location = new System.Drawing.Point(374, 35);
            this.TunnelId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TunnelId.Name = "TunnelId";
            this.TunnelId.Size = new System.Drawing.Size(0, 17);
            this.TunnelId.TabIndex = 2;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(374, 67);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(0, 17);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Click += new System.EventHandler(this.NameLabel_Click);
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.Location = new System.Drawing.Point(12, 26);
            this.StatisticsButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(128, 25);
            this.StatisticsButton.TabIndex = 4;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = true;
            this.StatisticsButton.Click += new System.EventHandler(this.StatisticsButton_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 91);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Send Panel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GetScene
            // 
            this.GetScene.Location = new System.Drawing.Point(12, 123);
            this.GetScene.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GetScene.Name = "GetScene";
            this.GetScene.Size = new System.Drawing.Size(128, 25);
            this.GetScene.TabIndex = 6;
            this.GetScene.Text = "Get Scene";
            this.GetScene.UseVisualStyleBackColor = true;
            this.GetScene.Click += new System.EventHandler(this.GetScene_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 155);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 25);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // addTerrainButton
            // 
            this.addTerrainButton.Location = new System.Drawing.Point(163, 38);
            this.addTerrainButton.Name = "addTerrainButton";
            this.addTerrainButton.Size = new System.Drawing.Size(116, 23);
            this.addTerrainButton.TabIndex = 8;
            this.addTerrainButton.Text = "AddTerrain";
            this.addTerrainButton.UseVisualStyleBackColor = true;
            this.addTerrainButton.Click += new System.EventHandler(this.addTerrainButton_Click);
            // 
            // TunnelCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 444);
            this.Controls.Add(this.addTerrainButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.GetScene);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.TunnelId);
            this.Controls.Add(this.sedCommandButton);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "TunnelCommandForm";
            this.Text = "TunnelCommandForm";
            this.Load += new System.EventHandler(this.TunnelCommandForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sedCommandButton;
        private System.Windows.Forms.Label TunnelId;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button StatisticsButton;
        private Button button1;
        private Button GetScene;
        private Button button3;
        private Button addTerrainButton;
    }
}