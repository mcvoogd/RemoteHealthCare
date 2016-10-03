using System.Windows.Forms;

namespace VRFrom_Gijs.Forms
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
            this.TunnelId = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SetTime = new System.Windows.Forms.TrackBar();
            this.createSceneButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SetTime)).BeginInit();
            this.SuspendLayout();
            // 
            // TunnelId
            // 
            this.TunnelId.AutoSize = true;
            this.TunnelId.Location = new System.Drawing.Point(280, 29);
            this.TunnelId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TunnelId.Name = "TunnelId";
            this.TunnelId.Size = new System.Drawing.Size(0, 13);
            this.TunnelId.TabIndex = 2;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(280, 55);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(0, 13);
            this.NameLabel.TabIndex = 3;
            // 
            // SetTime
            // 
            this.SetTime.Location = new System.Drawing.Point(-1, 69);
            this.SetTime.Margin = new System.Windows.Forms.Padding(1);
            this.SetTime.Maximum = 96;
            this.SetTime.Name = "SetTime";
            this.SetTime.Size = new System.Drawing.Size(316, 45);
            this.SetTime.TabIndex = 9;
            this.SetTime.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // createSceneButton
            // 
            this.createSceneButton.Location = new System.Drawing.Point(12, 12);
            this.createSceneButton.Name = "createSceneButton";
            this.createSceneButton.Size = new System.Drawing.Size(78, 23);
            this.createSceneButton.TabIndex = 11;
            this.createSceneButton.Text = "Create scene";
            this.createSceneButton.UseVisualStyleBackColor = true;
            this.createSceneButton.Click += new System.EventHandler(this.createSceneButton_Click);
            // 
            // TunnelCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 114);
            this.Controls.Add(this.createSceneButton);
            this.Controls.Add(this.SetTime);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.TunnelId);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TunnelCommandForm";
            this.Text = "TunnelCommandForm";
            ((System.ComponentModel.ISupportInitialize)(this.SetTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TunnelId;
        private System.Windows.Forms.Label NameLabel;
        private TrackBar SetTime;
        private Button createSceneButton;
    }
}