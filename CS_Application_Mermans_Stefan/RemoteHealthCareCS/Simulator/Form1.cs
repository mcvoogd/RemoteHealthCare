using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            simulator = new SimulatorClass();
        }

        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.hartslagMinButton = new System.Windows.Forms.Button();
            this.hartslagPlusButton = new System.Windows.Forms.Button();
            this.hartslagLabel = new System.Windows.Forms.Label();
            this.hartslagGetal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // hartslagMinButton
            // 
            this.hartslagMinButton.Location = new System.Drawing.Point(46, 81);
            this.hartslagMinButton.Name = "hartslagMinButton";
            this.hartslagMinButton.Size = new System.Drawing.Size(41, 23);
            this.hartslagMinButton.TabIndex = 2;
            this.hartslagMinButton.Text = "-";
            this.hartslagMinButton.UseVisualStyleBackColor = true;
            this.hartslagMinButton.Click += new System.EventHandler(this.hartslagMinButton_Click);
            // 
            // hartslagPlusButton
            // 
            this.hartslagPlusButton.Location = new System.Drawing.Point(160, 81);
            this.hartslagPlusButton.Name = "hartslagPlusButton";
            this.hartslagPlusButton.Size = new System.Drawing.Size(41, 23);
            this.hartslagPlusButton.TabIndex = 3;
            this.hartslagPlusButton.Text = "+";
            this.hartslagPlusButton.UseVisualStyleBackColor = true;
            this.hartslagPlusButton.Click += new System.EventHandler(this.hartslagPlusButton_Click);
            // 
            // hartslagLabel
            // 
            this.hartslagLabel.AutoSize = true;
            this.hartslagLabel.Location = new System.Drawing.Point(93, 61);
            this.hartslagLabel.Name = "hartslagLabel";
            this.hartslagLabel.Size = new System.Drawing.Size(61, 17);
            this.hartslagLabel.TabIndex = 1;
            this.hartslagLabel.Text = "Hartslag";
            // 
            // hartslagGetal
            // 
            this.hartslagGetal.AutoSize = true;
            this.hartslagGetal.Location = new System.Drawing.Point(116, 84);
            this.hartslagGetal.Name = "hartslagGetal";
            this.hartslagGetal.Size = new System.Drawing.Size(16, 17);
            this.hartslagGetal.TabIndex = 4;
            this.hartslagGetal.Text = "" + simulator.get;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(960, 575);
            this.Controls.Add(this.hartslagGetal);
            this.Controls.Add(this.hartslagPlusButton);
            this.Controls.Add(this.hartslagMinButton);
            this.Controls.Add(this.hartslagLabel);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "Start") { startButton.Text = "Stop"; }
            else if (startButton.Text == "Stop") { startButton.Text = "Start"; }
        }

        private void hartslagMinButton_Click(object sender, EventArgs e)
        {
            if (hartslag > 0) { hartslag--; }
            hartslagGetal.Text = "" + hartslag;
        }

        private void hartslagPlusButton_Click(object sender, EventArgs e)
        {
            if (hartslag < 200) { hartslag++; }
            hartslagGetal.Text = "" + hartslag;
        }
    }
}
