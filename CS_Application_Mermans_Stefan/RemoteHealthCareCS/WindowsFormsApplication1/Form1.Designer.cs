﻿namespace WindowsFormsApplication1
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
            this.pulseLabel = new System.Windows.Forms.Label();
            this.pulseCount = new System.Windows.Forms.Label();
            this.pulsePlus = new System.Windows.Forms.Button();
            this.pulseMin = new System.Windows.Forms.Button();
            this.rotationMin = new System.Windows.Forms.Button();
            this.rotationPlus = new System.Windows.Forms.Button();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.rotationsCount = new System.Windows.Forms.Label();
            this.speedMin = new System.Windows.Forms.Button();
            this.speedPlus = new System.Windows.Forms.Button();
            this.speedCount = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.powerLabel = new System.Windows.Forms.Label();
            this.powerMin = new System.Windows.Forms.Button();
            this.powerPlus = new System.Windows.Forms.Button();
            this.powerCount = new System.Windows.Forms.Label();
            this.burnedLabel = new System.Windows.Forms.Label();
            this.burnedMin = new System.Windows.Forms.Button();
            this.burnedPlus = new System.Windows.Forms.Button();
            this.burnedCount = new System.Windows.Forms.Label();
            this.tijdLabel = new System.Windows.Forms.Label();
            this.timeMin = new System.Windows.Forms.Button();
            this.timePlus = new System.Windows.Forms.Button();
            this.timeCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reachedPowerMin = new System.Windows.Forms.Button();
            this.reachedPowerPlus = new System.Windows.Forms.Button();
            this.reachedPowerCount = new System.Windows.Forms.Label();
            this.verzendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pulseLabel
            // 
            this.pulseLabel.AutoSize = true;
            this.pulseLabel.Location = new System.Drawing.Point(12, 15);
            this.pulseLabel.Name = "pulseLabel";
            this.pulseLabel.Size = new System.Drawing.Size(61, 17);
            this.pulseLabel.TabIndex = 0;
            this.pulseLabel.Text = "Hartslag";
            // 
            // pulseCount
            // 
            this.pulseCount.AutoSize = true;
            this.pulseCount.Location = new System.Drawing.Point(204, 15);
            this.pulseCount.Name = "pulseCount";
            this.pulseCount.Size = new System.Drawing.Size(32, 17);
            this.pulseCount.TabIndex = 1;
            this.pulseCount.Text = "120";
            // 
            // pulsePlus
            // 
            this.pulsePlus.Location = new System.Drawing.Point(242, 12);
            this.pulsePlus.Name = "pulsePlus";
            this.pulsePlus.Size = new System.Drawing.Size(34, 23);
            this.pulsePlus.TabIndex = 2;
            this.pulsePlus.Text = "+";
            this.pulsePlus.UseVisualStyleBackColor = true;
            this.pulsePlus.Click += new System.EventHandler(this.pulsePlus_Click);
            // 
            // pulseMin
            // 
            this.pulseMin.Location = new System.Drawing.Point(164, 12);
            this.pulseMin.Name = "pulseMin";
            this.pulseMin.Size = new System.Drawing.Size(34, 23);
            this.pulseMin.TabIndex = 3;
            this.pulseMin.Text = "-";
            this.pulseMin.UseVisualStyleBackColor = true;
            this.pulseMin.Click += new System.EventHandler(this.pulseMin_Click);
            // 
            // rotationMin
            // 
            this.rotationMin.Location = new System.Drawing.Point(164, 41);
            this.rotationMin.Name = "rotationMin";
            this.rotationMin.Size = new System.Drawing.Size(34, 23);
            this.rotationMin.TabIndex = 4;
            this.rotationMin.Text = "-";
            this.rotationMin.UseVisualStyleBackColor = true;
            this.rotationMin.Click += new System.EventHandler(this.rotationMin_Click);
            // 
            // rotationPlus
            // 
            this.rotationPlus.Location = new System.Drawing.Point(242, 41);
            this.rotationPlus.Name = "rotationPlus";
            this.rotationPlus.Size = new System.Drawing.Size(34, 23);
            this.rotationPlus.TabIndex = 5;
            this.rotationPlus.Text = "+";
            this.rotationPlus.UseVisualStyleBackColor = true;
            this.rotationPlus.Click += new System.EventHandler(this.rotationPlus_Click);
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Location = new System.Drawing.Point(12, 44);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(128, 17);
            this.rotationLabel.TabIndex = 6;
            this.rotationLabel.Text = "Rondes per minuut";
            // 
            // rotationsCount
            // 
            this.rotationsCount.AutoSize = true;
            this.rotationsCount.Location = new System.Drawing.Point(204, 44);
            this.rotationsCount.Name = "rotationsCount";
            this.rotationsCount.Size = new System.Drawing.Size(32, 17);
            this.rotationsCount.TabIndex = 7;
            this.rotationsCount.Text = "100";
            // 
            // speedMin
            // 
            this.speedMin.Location = new System.Drawing.Point(164, 70);
            this.speedMin.Name = "speedMin";
            this.speedMin.Size = new System.Drawing.Size(34, 23);
            this.speedMin.TabIndex = 8;
            this.speedMin.Text = "-";
            this.speedMin.UseVisualStyleBackColor = true;
            this.speedMin.Click += new System.EventHandler(this.speedMin_Click);
            // 
            // speedPlus
            // 
            this.speedPlus.Location = new System.Drawing.Point(242, 70);
            this.speedPlus.Name = "speedPlus";
            this.speedPlus.Size = new System.Drawing.Size(34, 23);
            this.speedPlus.TabIndex = 9;
            this.speedPlus.Text = "+";
            this.speedPlus.UseVisualStyleBackColor = true;
            this.speedPlus.Click += new System.EventHandler(this.speedPlus_Click);
            // 
            // speedCount
            // 
            this.speedCount.AutoSize = true;
            this.speedCount.Location = new System.Drawing.Point(204, 73);
            this.speedCount.Name = "speedCount";
            this.speedCount.Size = new System.Drawing.Size(24, 17);
            this.speedCount.TabIndex = 10;
            this.speedCount.Text = "25";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(12, 73);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(63, 17);
            this.speedLabel.TabIndex = 11;
            this.speedLabel.Text = "Snelheid";
            // 
            // powerLabel
            // 
            this.powerLabel.AutoSize = true;
            this.powerLabel.Location = new System.Drawing.Point(12, 102);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(73, 17);
            this.powerLabel.TabIndex = 12;
            this.powerLabel.Text = "Vermogen";
            // 
            // powerMin
            // 
            this.powerMin.Location = new System.Drawing.Point(164, 99);
            this.powerMin.Name = "powerMin";
            this.powerMin.Size = new System.Drawing.Size(34, 23);
            this.powerMin.TabIndex = 13;
            this.powerMin.Text = "-";
            this.powerMin.UseVisualStyleBackColor = true;
            this.powerMin.Click += new System.EventHandler(this.powerMin_Click);
            // 
            // powerPlus
            // 
            this.powerPlus.Location = new System.Drawing.Point(242, 99);
            this.powerPlus.Name = "powerPlus";
            this.powerPlus.Size = new System.Drawing.Size(34, 23);
            this.powerPlus.TabIndex = 14;
            this.powerPlus.Text = "+";
            this.powerPlus.UseVisualStyleBackColor = true;
            this.powerPlus.Click += new System.EventHandler(this.powerPlus_Click);
            // 
            // powerCount
            // 
            this.powerCount.AutoSize = true;
            this.powerCount.Location = new System.Drawing.Point(204, 102);
            this.powerCount.Name = "powerCount";
            this.powerCount.Size = new System.Drawing.Size(24, 17);
            this.powerCount.TabIndex = 15;
            this.powerCount.Text = "50";
            // 
            // burnedLabel
            // 
            this.burnedLabel.AutoSize = true;
            this.burnedLabel.Location = new System.Drawing.Point(12, 131);
            this.burnedLabel.Name = "burnedLabel";
            this.burnedLabel.Size = new System.Drawing.Size(127, 17);
            this.burnedLabel.TabIndex = 16;
            this.burnedLabel.Text = "Verbrande energie";
            // 
            // burnedMin
            // 
            this.burnedMin.Location = new System.Drawing.Point(164, 128);
            this.burnedMin.Name = "burnedMin";
            this.burnedMin.Size = new System.Drawing.Size(34, 23);
            this.burnedMin.TabIndex = 17;
            this.burnedMin.Text = "-";
            this.burnedMin.UseVisualStyleBackColor = true;
            this.burnedMin.Click += new System.EventHandler(this.burnedMin_Click);
            // 
            // burnedPlus
            // 
            this.burnedPlus.Location = new System.Drawing.Point(242, 128);
            this.burnedPlus.Name = "burnedPlus";
            this.burnedPlus.Size = new System.Drawing.Size(34, 23);
            this.burnedPlus.TabIndex = 18;
            this.burnedPlus.Text = "+";
            this.burnedPlus.UseVisualStyleBackColor = true;
            this.burnedPlus.Click += new System.EventHandler(this.burnedPlus_Click);
            // 
            // burnedCount
            // 
            this.burnedCount.AutoSize = true;
            this.burnedCount.Location = new System.Drawing.Point(204, 131);
            this.burnedCount.Name = "burnedCount";
            this.burnedCount.Size = new System.Drawing.Size(32, 17);
            this.burnedCount.TabIndex = 19;
            this.burnedCount.Text = "420";
            // 
            // tijdLabel
            // 
            this.tijdLabel.AutoSize = true;
            this.tijdLabel.Location = new System.Drawing.Point(12, 160);
            this.tijdLabel.Name = "tijdLabel";
            this.tijdLabel.Size = new System.Drawing.Size(102, 17);
            this.tijdLabel.TabIndex = 20;
            this.tijdLabel.Text = "Tijd verstreken";
            // 
            // timeMin
            // 
            this.timeMin.Location = new System.Drawing.Point(164, 157);
            this.timeMin.Name = "timeMin";
            this.timeMin.Size = new System.Drawing.Size(34, 23);
            this.timeMin.TabIndex = 21;
            this.timeMin.Text = "-";
            this.timeMin.UseVisualStyleBackColor = true;
            this.timeMin.Click += new System.EventHandler(this.timeMin_Click);
            // 
            // timePlus
            // 
            this.timePlus.Location = new System.Drawing.Point(242, 157);
            this.timePlus.Name = "timePlus";
            this.timePlus.Size = new System.Drawing.Size(34, 23);
            this.timePlus.TabIndex = 22;
            this.timePlus.Text = "+";
            this.timePlus.UseVisualStyleBackColor = true;
            this.timePlus.Click += new System.EventHandler(this.timePlus_Click);
            // 
            // timeCount
            // 
            this.timeCount.AutoSize = true;
            this.timeCount.Location = new System.Drawing.Point(204, 160);
            this.timeCount.Name = "timeCount";
            this.timeCount.Size = new System.Drawing.Size(32, 17);
            this.timeCount.TabIndex = 23;
            this.timeCount.Text = "120";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Gehaald vermogen";
            // 
            // reachedPowerMin
            // 
            this.reachedPowerMin.Location = new System.Drawing.Point(164, 186);
            this.reachedPowerMin.Name = "reachedPowerMin";
            this.reachedPowerMin.Size = new System.Drawing.Size(34, 23);
            this.reachedPowerMin.TabIndex = 25;
            this.reachedPowerMin.Text = "-";
            this.reachedPowerMin.UseVisualStyleBackColor = true;
            this.reachedPowerMin.Click += new System.EventHandler(this.reachedPowerMin_Click);
            // 
            // reachedPowerPlus
            // 
            this.reachedPowerPlus.Location = new System.Drawing.Point(242, 186);
            this.reachedPowerPlus.Name = "reachedPowerPlus";
            this.reachedPowerPlus.Size = new System.Drawing.Size(34, 23);
            this.reachedPowerPlus.TabIndex = 26;
            this.reachedPowerPlus.Text = "+";
            this.reachedPowerPlus.UseVisualStyleBackColor = true;
            this.reachedPowerPlus.Click += new System.EventHandler(this.reachedPowerPlus_Click);
            // 
            // reachedPowerCount
            // 
            this.reachedPowerCount.AutoSize = true;
            this.reachedPowerCount.Location = new System.Drawing.Point(204, 189);
            this.reachedPowerCount.Name = "reachedPowerCount";
            this.reachedPowerCount.Size = new System.Drawing.Size(32, 17);
            this.reachedPowerCount.TabIndex = 27;
            this.reachedPowerCount.Text = "666";
            // 
            // verzendButton
            // 
            this.verzendButton.Location = new System.Drawing.Point(12, 242);
            this.verzendButton.Name = "verzendButton";
            this.verzendButton.Size = new System.Drawing.Size(141, 41);
            this.verzendButton.TabIndex = 28;
            this.verzendButton.Text = "Verzend opdracht";
            this.verzendButton.UseVisualStyleBackColor = true;
            this.verzendButton.Click += new System.EventHandler(this.verzendButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 295);
            this.Controls.Add(this.verzendButton);
            this.Controls.Add(this.reachedPowerCount);
            this.Controls.Add(this.reachedPowerPlus);
            this.Controls.Add(this.reachedPowerMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeCount);
            this.Controls.Add(this.timePlus);
            this.Controls.Add(this.timeMin);
            this.Controls.Add(this.tijdLabel);
            this.Controls.Add(this.burnedCount);
            this.Controls.Add(this.burnedPlus);
            this.Controls.Add(this.burnedMin);
            this.Controls.Add(this.burnedLabel);
            this.Controls.Add(this.powerCount);
            this.Controls.Add(this.powerPlus);
            this.Controls.Add(this.powerMin);
            this.Controls.Add(this.powerLabel);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.speedCount);
            this.Controls.Add(this.speedPlus);
            this.Controls.Add(this.speedMin);
            this.Controls.Add(this.rotationsCount);
            this.Controls.Add(this.rotationLabel);
            this.Controls.Add(this.rotationPlus);
            this.Controls.Add(this.rotationMin);
            this.Controls.Add(this.pulseMin);
            this.Controls.Add(this.pulsePlus);
            this.Controls.Add(this.pulseCount);
            this.Controls.Add(this.pulseLabel);
            this.Name = "Form1";
            this.Text = "Fiets Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pulseLabel;
        private System.Windows.Forms.Label pulseCount;
        private System.Windows.Forms.Button pulsePlus;
        private System.Windows.Forms.Button pulseMin;
        private System.Windows.Forms.Button rotationMin;
        private System.Windows.Forms.Button rotationPlus;
        private System.Windows.Forms.Label rotationLabel;
        private System.Windows.Forms.Label rotationsCount;
        private System.Windows.Forms.Button speedMin;
        private System.Windows.Forms.Button speedPlus;
        private System.Windows.Forms.Label speedCount;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label powerLabel;
        private System.Windows.Forms.Button powerMin;
        private System.Windows.Forms.Button powerPlus;
        private System.Windows.Forms.Label powerCount;
        private System.Windows.Forms.Label burnedLabel;
        private System.Windows.Forms.Button burnedMin;
        private System.Windows.Forms.Button burnedPlus;
        private System.Windows.Forms.Label burnedCount;
        private System.Windows.Forms.Label tijdLabel;
        private System.Windows.Forms.Button timeMin;
        private System.Windows.Forms.Button timePlus;
        private System.Windows.Forms.Label timeCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reachedPowerMin;
        private System.Windows.Forms.Button reachedPowerPlus;
        private System.Windows.Forms.Label reachedPowerCount;
        private System.Windows.Forms.Button verzendButton;
    }
}

