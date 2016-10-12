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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcountCreationForm));
            this.errorPasswordsMatchLabel = new System.Windows.Forms.Label();
            this.errorEmptyFIeldLabel = new System.Windows.Forms.Label();
            this.serverIpLabel = new System.Windows.Forms.Label();
            this.passWordBoxTwo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.passwordBoxOne = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorPasswordsMatchLabel
            // 
            this.errorPasswordsMatchLabel.AutoSize = true;
            this.errorPasswordsMatchLabel.ForeColor = System.Drawing.Color.Red;
            this.errorPasswordsMatchLabel.Location = new System.Drawing.Point(7, 233);
            this.errorPasswordsMatchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.errorPasswordsMatchLabel.Name = "errorPasswordsMatchLabel";
            this.errorPasswordsMatchLabel.Size = new System.Drawing.Size(177, 13);
            this.errorPasswordsMatchLabel.TabIndex = 7;
            this.errorPasswordsMatchLabel.Text = "Wachtwoorden komen niet overeen";
            // 
            // errorEmptyFIeldLabel
            // 
            this.errorEmptyFIeldLabel.AutoSize = true;
            this.errorEmptyFIeldLabel.ForeColor = System.Drawing.Color.Red;
            this.errorEmptyFIeldLabel.Location = new System.Drawing.Point(6, 234);
            this.errorEmptyFIeldLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.errorEmptyFIeldLabel.Name = "errorEmptyFIeldLabel";
            this.errorEmptyFIeldLabel.Size = new System.Drawing.Size(87, 13);
            this.errorEmptyFIeldLabel.TabIndex = 8;
            this.errorEmptyFIeldLabel.Text = "Vul alle velden in";
            // 
            // serverIpLabel
            // 
            this.serverIpLabel.AutoSize = true;
            this.serverIpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIpLabel.Location = new System.Drawing.Point(7, 170);
            this.serverIpLabel.Name = "serverIpLabel";
            this.serverIpLabel.Size = new System.Drawing.Size(144, 18);
            this.serverIpLabel.TabIndex = 19;
            this.serverIpLabel.Text = "Herhaal wachtwoord";
            // 
            // passWordBoxTwo
            // 
            this.passWordBoxTwo.Location = new System.Drawing.Point(152, 172);
            this.passWordBoxTwo.Margin = new System.Windows.Forms.Padding(2);
            this.passWordBoxTwo.Name = "passWordBoxTwo";
            this.passWordBoxTwo.Size = new System.Drawing.Size(100, 20);
            this.passWordBoxTwo.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(151, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Aanmaken";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(7, 146);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(93, 18);
            this.password.TabIndex = 16;
            this.password.Text = "Wachtwoord";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(6, 122);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(95, 18);
            this.username.TabIndex = 14;
            this.username.Text = "Naam patient";
            // 
            // passwordBoxOne
            // 
            this.passwordBoxOne.Location = new System.Drawing.Point(152, 149);
            this.passwordBoxOne.Name = "passwordBoxOne";
            this.passwordBoxOne.PasswordChar = '•';
            this.passwordBoxOne.Size = new System.Drawing.Size(100, 20);
            this.passwordBoxOne.TabIndex = 12;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(152, 125);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 11;
            // 
            // AcountCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 255);
            this.Controls.Add(this.serverIpLabel);
            this.Controls.Add(this.passWordBoxTwo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.passwordBoxOne);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.errorEmptyFIeldLabel);
            this.Controls.Add(this.errorPasswordsMatchLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AcountCreationForm";
            this.Text = "Account aanmaken";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label errorPasswordsMatchLabel;
        private System.Windows.Forms.Label errorEmptyFIeldLabel;
        private System.Windows.Forms.Label serverIpLabel;
        private System.Windows.Forms.TextBox passWordBoxTwo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.TextBox passwordBoxOne;
        private System.Windows.Forms.TextBox NameTextBox;
    }
}