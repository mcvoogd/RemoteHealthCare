﻿using System;
using System.Windows.Forms;

namespace DataScreen.Forms
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "admin" && passwordTextBox.Text == "admin")
            {
                this.DialogResult = DialogResult.OK;
            }
            else if (usernameTextBox.Text == "guest" && passwordTextBox.Text == "guest")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                wrongLogin.Visible = true;
            }
        }
    }
}
