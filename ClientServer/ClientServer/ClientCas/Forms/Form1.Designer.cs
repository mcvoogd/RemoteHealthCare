namespace ClientCas
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 18;
            this.listBox.Location = new System.Drawing.Point(-2, -1);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(1007, 598);
            this.listBox.TabIndex = 0;
            this.listBox.Visible = false;
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.Location = new System.Drawing.Point(81, 63);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(97, 28);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLabel.Location = new System.Drawing.Point(12, 36);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(63, 18);
            this.ipLabel.TabIndex = 2;
            this.ipLabel.Text = "IP-adres";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipTextBox.Location = new System.Drawing.Point(81, 33);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(211, 24);
            this.ipTextBox.TabIndex = 3;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(78, 94);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(299, 17);
            this.errorLabel.TabIndex = 4;
            this.errorLabel.Text = "This ip is invalid or the server is not turned on!";
            this.errorLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 598);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.listBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label errorLabel;
    }
}

