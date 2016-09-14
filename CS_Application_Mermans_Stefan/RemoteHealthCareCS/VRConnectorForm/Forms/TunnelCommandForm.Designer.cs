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
            this.addTerrainButton = new System.Windows.Forms.Button();
            this.SetTime = new System.Windows.Forms.TrackBar();
            this.CreateHouse = new System.Windows.Forms.Button();
            this.SendHouse = new System.Windows.Forms.Button();
            this.CreateRoute = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.FollowRoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SetTime)).BeginInit();
            this.SuspendLayout();
            // 
            // sedCommandButton
            // 
            this.sedCommandButton.Location = new System.Drawing.Point(9, 48);
            this.sedCommandButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.sedCommandButton.Name = "sedCommandButton";
            this.sedCommandButton.Size = new System.Drawing.Size(123, 20);
            this.sedCommandButton.TabIndex = 1;
            this.sedCommandButton.Text = "DeleteGroundLayer 2x";
            this.sedCommandButton.UseVisualStyleBackColor = true;
            this.sedCommandButton.Click += new System.EventHandler(this.sedCommandButton_Click);
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
            // StatisticsButton
            // 
            this.StatisticsButton.Location = new System.Drawing.Point(9, 21);
            this.StatisticsButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(123, 20);
            this.StatisticsButton.TabIndex = 4;
            this.StatisticsButton.Text = "ChangeTerrainTexture";
            this.StatisticsButton.UseVisualStyleBackColor = true;
            this.StatisticsButton.Click += new System.EventHandler(this.StatisticsButton_Click_1);
            // 
            // CreateAuto
            // 
            this.CreateAuto.Location = new System.Drawing.Point(179, 21);
            this.CreateAuto.Name = "CreateAuto";
            this.CreateAuto.Size = new System.Drawing.Size(96, 21);
            this.CreateAuto.TabIndex = 5;
            this.CreateAuto.Text = "Create Auto";
            this.CreateAuto.UseVisualStyleBackColor = true;
            this.CreateAuto.Click += new System.EventHandler(this.CreateAuto_Click);
            // 
            // SendAuto
            // 
            this.SendAuto.Location = new System.Drawing.Point(179, 45);
            this.SendAuto.Name = "SendAuto";
            this.SendAuto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SendAuto.Size = new System.Drawing.Size(96, 20);
            this.SendAuto.TabIndex = 6;
            this.SendAuto.Text = "Send Auto";
            this.SendAuto.UseVisualStyleBackColor = true;
            this.SendAuto.Click += new System.EventHandler(this.SendAuto_Click);
            // 
            // MoveCar
            // 
            this.MoveCar.Location = new System.Drawing.Point(179, 70);
            this.MoveCar.Margin = new System.Windows.Forms.Padding(2);
            this.MoveCar.Name = "MoveCar";
            this.MoveCar.Size = new System.Drawing.Size(96, 20);
            this.MoveCar.TabIndex = 7;
            this.MoveCar.Text = "Move Car";
            this.MoveCar.UseVisualStyleBackColor = true;
            this.MoveCar.Click += new System.EventHandler(this.MoveCar_Click);
            // 
            // addTerrainButton
            // 
            this.addTerrainButton.Location = new System.Drawing.Point(179, 106);
            this.addTerrainButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.addTerrainButton.Name = "addTerrainButton";
            this.addTerrainButton.Size = new System.Drawing.Size(96, 20);
            this.addTerrainButton.TabIndex = 8;
            this.addTerrainButton.Text = "AddTerrain";
            this.addTerrainButton.UseVisualStyleBackColor = true;
            this.addTerrainButton.Click += new System.EventHandler(this.addTerrainButton_Click);
            // 
            // SetTime
            // 
            this.SetTime.Location = new System.Drawing.Point(9, 306);
            this.SetTime.Margin = new System.Windows.Forms.Padding(1);
            this.SetTime.Maximum = 96;
            this.SetTime.Name = "SetTime";
            this.SetTime.Size = new System.Drawing.Size(316, 45);
            this.SetTime.TabIndex = 9;
            this.SetTime.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // CreateHouse
            // 
            this.CreateHouse.Location = new System.Drawing.Point(179, 167);
            this.CreateHouse.Name = "CreateHouse";
            this.CreateHouse.Size = new System.Drawing.Size(96, 20);
            this.CreateHouse.TabIndex = 10;
            this.CreateHouse.Text = "Create House";
            this.CreateHouse.UseVisualStyleBackColor = true;
            this.CreateHouse.Click += new System.EventHandler(this.CreateHouse_Click);
            // 
            // SendHouse
            // 
            this.SendHouse.Location = new System.Drawing.Point(179, 193);
            this.SendHouse.Name = "SendHouse";
            this.SendHouse.Size = new System.Drawing.Size(96, 20);
            this.SendHouse.TabIndex = 11;
            this.SendHouse.Text = "Send House";
            this.SendHouse.UseVisualStyleBackColor = true;
            this.SendHouse.Click += new System.EventHandler(this.SendHouse_Click);
            // 
            // CreateRoute
            // 
            this.CreateRoute.Location = new System.Drawing.Point(12, 141);
            this.CreateRoute.Name = "CreateRoute";
            this.CreateRoute.Size = new System.Drawing.Size(123, 20);
            this.CreateRoute.TabIndex = 12;
            this.CreateRoute.Text = "CreateRoute";
            this.CreateRoute.UseVisualStyleBackColor = true;
            this.CreateRoute.Click += new System.EventHandler(this.CreateRoute_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 20);
            this.button1.TabIndex = 13;
            this.button1.Text = "CreateRoad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FollowRoad
            // 
            this.FollowRoad.Location = new System.Drawing.Point(12, 193);
            this.FollowRoad.Name = "FollowRoad";
            this.FollowRoad.Size = new System.Drawing.Size(123, 20);
            this.FollowRoad.TabIndex = 14;
            this.FollowRoad.Text = "Follow Road";
            this.FollowRoad.UseVisualStyleBackColor = true;
            this.FollowRoad.Click += new System.EventHandler(this.FollowRoad_Click);
            // 
            // TunnelCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 361);
            this.Controls.Add(this.FollowRoad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CreateRoute);
            this.Controls.Add(this.SendHouse);
            this.Controls.Add(this.CreateHouse);
            this.Controls.Add(this.SetTime);
            this.Controls.Add(this.addTerrainButton);
            this.Controls.Add(this.MoveCar);
            this.Controls.Add(this.SendAuto);
            this.Controls.Add(this.CreateAuto);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.TunnelId);
            this.Controls.Add(this.sedCommandButton);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TunnelCommandForm";
            this.Text = "TunnelCommandForm";
            ((System.ComponentModel.ISupportInitialize)(this.SetTime)).EndInit();
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
        private Button addTerrainButton;
        private TrackBar SetTime;
        private Button CreateHouse;
        private Button SendHouse;
        private Button CreateRoute;
        private Button button1;
        private Button FollowRoad;
    }
}