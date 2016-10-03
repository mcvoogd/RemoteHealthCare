﻿using System;
using System.Windows.Forms;

namespace Doctor.Forms
{
    public delegate bool Connect(string serverIp, string username, string password);
    public partial class LoginForm : Form
    {
        private Connect _connect;
        private MainForm _mainForm;

        public LoginForm(Connect connect, MainForm mainForm)
        {
            FormClosing += LoginForm_FormClosing;
            _mainForm = mainForm;
            InitializeComponent();
            _connect = connect;
        }


        private static void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(_connect(severIpTextBox.Text, usernameTextBox.Text, passwordTextBox.Text))
            {
                Visible = false;
                _mainForm.Visible = true;

                _mainForm.userLabel.Text = usernameTextBox.Text;
                Console.WriteLine("USERNAME: " + usernameTextBox.Text);
            } else
            {
                wrongLogin.Visible = true;
            }
        }
    }
}
