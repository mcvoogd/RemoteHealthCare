namespace DataScreen.Forms
{
    partial class SimulationForm
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
            this.burnedCount = new System.Windows.Forms.Label();
            this.tijdLabel = new System.Windows.Forms.Label();
            this.timeMin = new System.Windows.Forms.Button();
            this.timePlus = new System.Windows.Forms.Button();
            this.timeCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reachedPowerMin = new System.Windows.Forms.Button();
            this.reachedPowerPlus = new System.Windows.Forms.Button();
            this.reachedPowerCount = new System.Windows.Forms.Label();
            this.distanceCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pulseLabel
            // 
            this.pulseLabel.AutoSize = true;
            this.pulseLabel.Location = new System.Drawing.Point(9, 12);
            this.pulseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pulseLabel.Name = "pulseLabel";
            this.pulseLabel.Size = new System.Drawing.Size(46, 13);
            this.pulseLabel.TabIndex = 0;
            this.pulseLabel.Text = "Hartslag";
            // 
            // pulseCount
            // 
            this.pulseCount.AutoSize = true;
            this.pulseCount.Location = new System.Drawing.Point(159, 13);
            this.pulseCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pulseCount.Name = "pulseCount";
            this.pulseCount.Size = new System.Drawing.Size(25, 13);
            this.pulseCount.TabIndex = 1;
            this.pulseCount.Text = "120";
            // 
            // pulsePlus
            // 
            this.pulsePlus.Location = new System.Drawing.Point(196, 10);
            this.pulsePlus.Margin = new System.Windows.Forms.Padding(2);
            this.pulsePlus.Name = "pulsePlus";
            this.pulsePlus.Size = new System.Drawing.Size(26, 19);
            this.pulsePlus.TabIndex = 2;
            this.pulsePlus.Text = "+";
            this.pulsePlus.UseVisualStyleBackColor = true;
            this.pulsePlus.Click += new System.EventHandler(this.pulsePlus_Click);
            // 
            // pulseMin
            // 
            this.pulseMin.Location = new System.Drawing.Point(123, 10);
            this.pulseMin.Margin = new System.Windows.Forms.Padding(2);
            this.pulseMin.Name = "pulseMin";
            this.pulseMin.Size = new System.Drawing.Size(26, 19);
            this.pulseMin.TabIndex = 3;
            this.pulseMin.Text = "-";
            this.pulseMin.UseVisualStyleBackColor = true;
            this.pulseMin.Click += new System.EventHandler(this.pulseMin_Click);
            // 
            // rotationMin
            // 
            this.rotationMin.Location = new System.Drawing.Point(123, 33);
            this.rotationMin.Margin = new System.Windows.Forms.Padding(2);
            this.rotationMin.Name = "rotationMin";
            this.rotationMin.Size = new System.Drawing.Size(26, 19);
            this.rotationMin.TabIndex = 4;
            this.rotationMin.Text = "-";
            this.rotationMin.UseVisualStyleBackColor = true;
            this.rotationMin.Click += new System.EventHandler(this.rotationMin_Click);
            // 
            // rotationPlus
            // 
            this.rotationPlus.Location = new System.Drawing.Point(196, 33);
            this.rotationPlus.Margin = new System.Windows.Forms.Padding(2);
            this.rotationPlus.Name = "rotationPlus";
            this.rotationPlus.Size = new System.Drawing.Size(26, 19);
            this.rotationPlus.TabIndex = 5;
            this.rotationPlus.Text = "+";
            this.rotationPlus.UseVisualStyleBackColor = true;
            this.rotationPlus.Click += new System.EventHandler(this.rotationPlus_Click);
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Location = new System.Drawing.Point(9, 36);
            this.rotationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(96, 13);
            this.rotationLabel.TabIndex = 6;
            this.rotationLabel.Text = "Rondes per minuut";
            // 
            // rotationsCount
            // 
            this.rotationsCount.AutoSize = true;
            this.rotationsCount.Location = new System.Drawing.Point(159, 36);
            this.rotationsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rotationsCount.Name = "rotationsCount";
            this.rotationsCount.Size = new System.Drawing.Size(25, 13);
            this.rotationsCount.TabIndex = 7;
            this.rotationsCount.Text = "100";
            // 
            // speedMin
            // 
            this.speedMin.Location = new System.Drawing.Point(123, 57);
            this.speedMin.Margin = new System.Windows.Forms.Padding(2);
            this.speedMin.Name = "speedMin";
            this.speedMin.Size = new System.Drawing.Size(26, 19);
            this.speedMin.TabIndex = 8;
            this.speedMin.Text = "-";
            this.speedMin.UseVisualStyleBackColor = true;
            this.speedMin.Click += new System.EventHandler(this.speedMin_Click);
            // 
            // speedPlus
            // 
            this.speedPlus.Location = new System.Drawing.Point(196, 57);
            this.speedPlus.Margin = new System.Windows.Forms.Padding(2);
            this.speedPlus.Name = "speedPlus";
            this.speedPlus.Size = new System.Drawing.Size(26, 19);
            this.speedPlus.TabIndex = 9;
            this.speedPlus.Text = "+";
            this.speedPlus.UseVisualStyleBackColor = true;
            this.speedPlus.Click += new System.EventHandler(this.speedPlus_Click);
            // 
            // speedCount
            // 
            this.speedCount.AutoSize = true;
            this.speedCount.Location = new System.Drawing.Point(159, 60);
            this.speedCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedCount.Name = "speedCount";
            this.speedCount.Size = new System.Drawing.Size(19, 13);
            this.speedCount.TabIndex = 10;
            this.speedCount.Text = "25";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(9, 59);
            this.speedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(48, 13);
            this.speedLabel.TabIndex = 11;
            this.speedLabel.Text = "Snelheid";
            // 
            // powerLabel
            // 
            this.powerLabel.AutoSize = true;
            this.powerLabel.Location = new System.Drawing.Point(9, 81);
            this.powerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(55, 13);
            this.powerLabel.TabIndex = 12;
            this.powerLabel.Text = "Vermogen";
            // 
            // powerMin
            // 
            this.powerMin.Location = new System.Drawing.Point(123, 81);
            this.powerMin.Margin = new System.Windows.Forms.Padding(2);
            this.powerMin.Name = "powerMin";
            this.powerMin.Size = new System.Drawing.Size(26, 19);
            this.powerMin.TabIndex = 13;
            this.powerMin.Text = "-";
            this.powerMin.UseVisualStyleBackColor = true;
            this.powerMin.Click += new System.EventHandler(this.powerMin_Click);
            // 
            // powerPlus
            // 
            this.powerPlus.Location = new System.Drawing.Point(196, 81);
            this.powerPlus.Margin = new System.Windows.Forms.Padding(2);
            this.powerPlus.Name = "powerPlus";
            this.powerPlus.Size = new System.Drawing.Size(26, 19);
            this.powerPlus.TabIndex = 14;
            this.powerPlus.Text = "+";
            this.powerPlus.UseVisualStyleBackColor = true;
            this.powerPlus.Click += new System.EventHandler(this.powerPlus_Click);
            // 
            // powerCount
            // 
            this.powerCount.AutoSize = true;
            this.powerCount.Location = new System.Drawing.Point(159, 84);
            this.powerCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.powerCount.Name = "powerCount";
            this.powerCount.Size = new System.Drawing.Size(19, 13);
            this.powerCount.TabIndex = 15;
            this.powerCount.Text = "50";
            // 
            // burnedLabel
            // 
            this.burnedLabel.AutoSize = true;
            this.burnedLabel.Location = new System.Drawing.Point(9, 152);
            this.burnedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.burnedLabel.Name = "burnedLabel";
            this.burnedLabel.Size = new System.Drawing.Size(94, 13);
            this.burnedLabel.TabIndex = 16;
            this.burnedLabel.Text = "Verbrande energie";
            // 
            // burnedCount
            // 
            this.burnedCount.AutoSize = true;
            this.burnedCount.Location = new System.Drawing.Point(159, 152);
            this.burnedCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.burnedCount.Name = "burnedCount";
            this.burnedCount.Size = new System.Drawing.Size(25, 13);
            this.burnedCount.TabIndex = 19;
            this.burnedCount.Text = "420";
            // 
            // tijdLabel
            // 
            this.tijdLabel.AutoSize = true;
            this.tijdLabel.Location = new System.Drawing.Point(9, 104);
            this.tijdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tijdLabel.Name = "tijdLabel";
            this.tijdLabel.Size = new System.Drawing.Size(77, 13);
            this.tijdLabel.TabIndex = 20;
            this.tijdLabel.Text = "Tijd verstreken";
            // 
            // timeMin
            // 
            this.timeMin.Location = new System.Drawing.Point(123, 104);
            this.timeMin.Margin = new System.Windows.Forms.Padding(2);
            this.timeMin.Name = "timeMin";
            this.timeMin.Size = new System.Drawing.Size(26, 19);
            this.timeMin.TabIndex = 21;
            this.timeMin.Text = "-";
            this.timeMin.UseVisualStyleBackColor = true;
            this.timeMin.Click += new System.EventHandler(this.timeMin_Click);
            // 
            // timePlus
            // 
            this.timePlus.Location = new System.Drawing.Point(196, 104);
            this.timePlus.Margin = new System.Windows.Forms.Padding(2);
            this.timePlus.Name = "timePlus";
            this.timePlus.Size = new System.Drawing.Size(26, 19);
            this.timePlus.TabIndex = 22;
            this.timePlus.Text = "+";
            this.timePlus.UseVisualStyleBackColor = true;
            this.timePlus.Click += new System.EventHandler(this.timePlus_Click);
            // 
            // timeCount
            // 
            this.timeCount.AutoSize = true;
            this.timeCount.Location = new System.Drawing.Point(153, 107);
            this.timeCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeCount.Name = "timeCount";
            this.timeCount.Size = new System.Drawing.Size(37, 13);
            this.timeCount.TabIndex = 23;
            this.timeCount.Text = "02:00 ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Gehaald vermogen";
            // 
            // reachedPowerMin
            // 
            this.reachedPowerMin.Location = new System.Drawing.Point(123, 127);
            this.reachedPowerMin.Margin = new System.Windows.Forms.Padding(2);
            this.reachedPowerMin.Name = "reachedPowerMin";
            this.reachedPowerMin.Size = new System.Drawing.Size(26, 19);
            this.reachedPowerMin.TabIndex = 25;
            this.reachedPowerMin.Text = "-";
            this.reachedPowerMin.UseVisualStyleBackColor = true;
            this.reachedPowerMin.Click += new System.EventHandler(this.reachedPowerMin_Click);
            // 
            // reachedPowerPlus
            // 
            this.reachedPowerPlus.Location = new System.Drawing.Point(196, 127);
            this.reachedPowerPlus.Margin = new System.Windows.Forms.Padding(2);
            this.reachedPowerPlus.Name = "reachedPowerPlus";
            this.reachedPowerPlus.Size = new System.Drawing.Size(26, 19);
            this.reachedPowerPlus.TabIndex = 26;
            this.reachedPowerPlus.Text = "+";
            this.reachedPowerPlus.UseVisualStyleBackColor = true;
            this.reachedPowerPlus.Click += new System.EventHandler(this.reachedPowerPlus_Click);
            // 
            // reachedPowerCount
            // 
            this.reachedPowerCount.AutoSize = true;
            this.reachedPowerCount.Location = new System.Drawing.Point(159, 130);
            this.reachedPowerCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.reachedPowerCount.Name = "reachedPowerCount";
            this.reachedPowerCount.Size = new System.Drawing.Size(25, 13);
            this.reachedPowerCount.TabIndex = 27;
            this.reachedPowerCount.Text = "666";
            // 
            // distanceCount
            // 
            this.distanceCount.AutoSize = true;
            this.distanceCount.Location = new System.Drawing.Point(159, 175);
            this.distanceCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.distanceCount.Name = "distanceCount";
            this.distanceCount.Size = new System.Drawing.Size(25, 13);
            this.distanceCount.TabIndex = 30;
            this.distanceCount.Text = "833";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Afstand";
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 207);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.distanceCount);
            this.Controls.Add(this.reachedPowerCount);
            this.Controls.Add(this.reachedPowerPlus);
            this.Controls.Add(this.reachedPowerMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeCount);
            this.Controls.Add(this.timePlus);
            this.Controls.Add(this.timeMin);
            this.Controls.Add(this.tijdLabel);
            this.Controls.Add(this.burnedCount);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SimulationForm";
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
        private System.Windows.Forms.Label burnedCount;
        private System.Windows.Forms.Label tijdLabel;
        private System.Windows.Forms.Button timeMin;
        private System.Windows.Forms.Button timePlus;
        private System.Windows.Forms.Label timeCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reachedPowerMin;
        private System.Windows.Forms.Button reachedPowerPlus;
        private System.Windows.Forms.Label reachedPowerCount;
        private System.Windows.Forms.Label distanceCount;
        private System.Windows.Forms.Label label3;
    }
}

