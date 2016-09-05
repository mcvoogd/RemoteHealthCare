namespace SimulatorApplication
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
            this.pulseMinButton = new System.Windows.Forms.Button();
            this.pulsePlusButton = new System.Windows.Forms.Button();
            this.pulseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pulseMinButton
            // 
            this.pulseMinButton.Location = new System.Drawing.Point(45, 62);
            this.pulseMinButton.Name = "pulseMinButton";
            this.pulseMinButton.Size = new System.Drawing.Size(39, 23);
            this.pulseMinButton.TabIndex = 0;
            this.pulseMinButton.Text = "-";
            this.pulseMinButton.UseVisualStyleBackColor = true;
            this.pulseMinButton.Click += new System.EventHandler(this.pulseMinButton_Click);
            // 
            // pulsePlusButton
            // 
            this.pulsePlusButton.Location = new System.Drawing.Point(142, 62);
            this.pulsePlusButton.Name = "pulsePlusButton";
            this.pulsePlusButton.Size = new System.Drawing.Size(39, 23);
            this.pulsePlusButton.TabIndex = 1;
            this.pulsePlusButton.Text = "+";
            this.pulsePlusButton.UseVisualStyleBackColor = true;
            this.pulsePlusButton.Click += new System.EventHandler(this.pulsePlusButton_Click);
            // 
            // pulseLabel
            // 
            this.pulseLabel.AutoSize = true;
            this.pulseLabel.Location = new System.Drawing.Point(105, 65);
            this.pulseLabel.Name = "pulseLabel";
            this.pulseLabel.Size = new System.Drawing.Size(24, 17);
            this.pulseLabel.TabIndex = 2;
            this.pulseLabel.Text = "70";
            this.pulseLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 510);
            this.Controls.Add(this.pulseLabel);
            this.Controls.Add(this.pulsePlusButton);
            this.Controls.Add(this.pulseMinButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pulseMinButton;
        private System.Windows.Forms.Button pulsePlusButton;
        private System.Windows.Forms.Label pulseLabel;
    }
}

