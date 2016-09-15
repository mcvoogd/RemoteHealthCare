﻿using System.Windows.Forms;

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
            this.sedCommandButton.Location = new System.Drawing.Point(24, 114);
            this.sedCommandButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.sedCommandButton.Name = "sedCommandButton";
            this.sedCommandButton.Size = new System.Drawing.Size(328, 48);
            this.sedCommandButton.TabIndex = 1;
            this.sedCommandButton.Text = "DeleteGroundLayer 2x";
            this.sedCommandButton.UseVisualStyleBackColor = true;
            this.sedCommandButton.Click += new System.EventHandler(this.sedCommandButton_Click);
            // 
            // TunnelId
            // 
            this.TunnelId.AutoSize = true;
            this.TunnelId.Location = new System.Drawing.Point(747, 69);
            this.TunnelId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TunnelId.Name = "TunnelId";
            this.TunnelId.Size = new System.Drawing.Size(0, 32);
            this.TunnelId.TabIndex = 2;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(747, 131);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(0, 32);
            this.NameLabel.TabIndex = 3;
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.Location = new System.Drawing.Point(24, 50);
            this.StatisticsButton.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(328, 48);
            this.StatisticsButton.TabIndex = 4;
            this.StatisticsButton.Text = "ChangeTerrainTexture";
            this.StatisticsButton.UseVisualStyleBackColor = true;
            this.StatisticsButton.Click += new System.EventHandler(this.StatisticsButton_Click_1);
            // 
            // CreateAuto
            // 
            this.CreateAuto.Location = new System.Drawing.Point(477, 50);
            this.CreateAuto.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.CreateAuto.Name = "CreateAuto";
            this.CreateAuto.Size = new System.Drawing.Size(256, 50);
            this.CreateAuto.TabIndex = 5;
            this.CreateAuto.Text = "Create Auto";
            this.CreateAuto.UseVisualStyleBackColor = true;
            this.CreateAuto.Click += new System.EventHandler(this.CreateAuto_Click);
            // 
            // SendAuto
            // 
            this.SendAuto.Location = new System.Drawing.Point(477, 107);
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
            this.MoveCar.Location = new System.Drawing.Point(477, 167);
            this.MoveCar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MoveCar.Name = "MoveCar";
            this.MoveCar.Size = new System.Drawing.Size(256, 48);
            this.MoveCar.TabIndex = 7;
            this.MoveCar.Text = "Move Car";
            this.MoveCar.UseVisualStyleBackColor = true;
            this.MoveCar.Click += new System.EventHandler(this.MoveCar_Click);
            // 
            // addTerrainButton
            // 
            this.addTerrainButton.Location = new System.Drawing.Point(477, 253);
            this.addTerrainButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.addTerrainButton.Name = "addTerrainButton";
            this.addTerrainButton.Size = new System.Drawing.Size(256, 48);
            this.addTerrainButton.TabIndex = 8;
            this.addTerrainButton.Text = "AddTerrain";
            this.addTerrainButton.UseVisualStyleBackColor = true;
            this.addTerrainButton.Click += new System.EventHandler(this.addTerrainButton_Click);
            // 
            // SetTime
            // 
            this.SetTime.Location = new System.Drawing.Point(24, 730);
            this.SetTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SetTime.Maximum = 96;
            this.SetTime.Name = "SetTime";
            this.SetTime.Size = new System.Drawing.Size(843, 114);
            this.SetTime.TabIndex = 9;
            this.SetTime.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // CreateHouse
            // 
            this.CreateHouse.Location = new System.Drawing.Point(477, 398);
            this.CreateHouse.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.CreateHouse.Name = "CreateHouse";
            this.CreateHouse.Size = new System.Drawing.Size(256, 48);
            this.CreateHouse.TabIndex = 10;
            this.CreateHouse.Text = "Create House";
            this.CreateHouse.UseVisualStyleBackColor = true;
            this.CreateHouse.Click += new System.EventHandler(this.CreateHouse_Click);
            // 
            // SendHouse
            // 
            this.SendHouse.Location = new System.Drawing.Point(477, 460);
            this.SendHouse.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.SendHouse.Name = "SendHouse";
            this.SendHouse.Size = new System.Drawing.Size(256, 48);
            this.SendHouse.TabIndex = 11;
            this.SendHouse.Text = "Send House";
            this.SendHouse.UseVisualStyleBackColor = true;
            this.SendHouse.Click += new System.EventHandler(this.SendHouse_Click);
            // 
            // CreateRoute
            // 
            this.CreateRoute.Location = new System.Drawing.Point(32, 336);
            this.CreateRoute.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.CreateRoute.Name = "CreateRoute";
            this.CreateRoute.Size = new System.Drawing.Size(328, 48);
            this.CreateRoute.TabIndex = 12;
            this.CreateRoute.Text = "CreateRoute";
            this.CreateRoute.UseVisualStyleBackColor = true;
            this.CreateRoute.Click += new System.EventHandler(this.CreateRoute_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 398);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(328, 48);
            this.button1.TabIndex = 13;
            this.button1.Text = "CreateRoad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FollowRoad
            // 
            this.FollowRoad.Location = new System.Drawing.Point(32, 460);
            this.FollowRoad.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.FollowRoad.Name = "FollowRoad";
            this.FollowRoad.Size = new System.Drawing.Size(328, 48);
            this.FollowRoad.TabIndex = 14;
            this.FollowRoad.Text = "Follow Road";
            this.FollowRoad.UseVisualStyleBackColor = true;
            this.FollowRoad.Click += new System.EventHandler(this.FollowRoad_Click);
            // 
            // TunnelCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 861);
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
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
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