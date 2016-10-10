namespace Doctor.Forms
{
    partial class AcountCreationForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.passwordBoxOne = new System.Windows.Forms.TextBox();
            this.passWordBoxTwo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorPasswordsMatchLabel = new System.Windows.Forms.Label();
            this.errorEmptyFIeldLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Klaar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naam patient:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wachtwoord patient:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(13, 34);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(257, 22);
            this.NameTextBox.TabIndex = 3;
            // 
            // passwordBoxOne
            // 
            this.passwordBoxOne.Location = new System.Drawing.Point(12, 79);
            this.passwordBoxOne.Name = "passwordBoxOne";
            this.passwordBoxOne.PasswordChar = '•';
            this.passwordBoxOne.Size = new System.Drawing.Size(258, 22);
            this.passwordBoxOne.TabIndex = 4;
            // 
            // passWordBoxTwo
            // 
            this.passWordBoxTwo.Location = new System.Drawing.Point(12, 124);
            this.passWordBoxTwo.Name = "passWordBoxTwo";
            this.passWordBoxTwo.PasswordChar = '•';
            this.passWordBoxTwo.Size = new System.Drawing.Size(258, 22);
            this.passWordBoxTwo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Herhaal wachtwoord:";
            // 
            // errorPasswordsMatchLabel
            // 
            this.errorPasswordsMatchLabel.AutoSize = true;
            this.errorPasswordsMatchLabel.ForeColor = System.Drawing.Color.Red;
            this.errorPasswordsMatchLabel.Location = new System.Drawing.Point(13, 181);
            this.errorPasswordsMatchLabel.Name = "errorPasswordsMatchLabel";
            this.errorPasswordsMatchLabel.Size = new System.Drawing.Size(231, 17);
            this.errorPasswordsMatchLabel.TabIndex = 7;
            this.errorPasswordsMatchLabel.Text = "Wachtwoorden komen niet overeen";
            // 
            // errorEmptyFIeldLabel
            // 
            this.errorEmptyFIeldLabel.AutoSize = true;
            this.errorEmptyFIeldLabel.ForeColor = System.Drawing.Color.Red;
            this.errorEmptyFIeldLabel.Location = new System.Drawing.Point(12, 182);
            this.errorEmptyFIeldLabel.Name = "errorEmptyFIeldLabel";
            this.errorEmptyFIeldLabel.Size = new System.Drawing.Size(115, 17);
            this.errorEmptyFIeldLabel.TabIndex = 8;
            this.errorEmptyFIeldLabel.Text = "Vul alle velden in";
            // 
            // AcountCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 207);
            this.Controls.Add(this.errorEmptyFIeldLabel);
            this.Controls.Add(this.errorPasswordsMatchLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passWordBoxTwo);
            this.Controls.Add(this.passwordBoxOne);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "AcountCreationForm";
            this.Text = "AcountCreationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox passwordBoxOne;
        private System.Windows.Forms.TextBox passWordBoxTwo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label errorPasswordsMatchLabel;
        private System.Windows.Forms.Label errorEmptyFIeldLabel;
    }
}