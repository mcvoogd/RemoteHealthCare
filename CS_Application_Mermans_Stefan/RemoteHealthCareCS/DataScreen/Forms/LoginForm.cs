﻿using System;
using System.Windows.Forms;

namespace DataScreen.Forms
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
            //passwordTextBox.MouseHover += new EventHandler(passwordTextBox_MouseHover);
            //passwordTextBox.MouseLeave += new EventHandler(passwordTextBox_MouseLeave);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "admin" && passwordTextBox.Text == "admin")
            {
                DialogResult = DialogResult.OK;
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

//        ToolTip toolTipCaps = new ToolTip();
//        void passwordTextBox_MouseLeave(object sender, EventArgs e)
//        {
//            toolTipCaps.Hide(passwordTextBox);
//        }
//        void passwordTextBox_MouseHover(object sender, EventArgs e)
//        {
//            if (Control.IsKeyLocked(Keys.CapsLock))
//            {
//
//                toolTipCaps.ToolTipTitle = "Caps Lock Is On";
//                toolTipCaps.ToolTipIcon = ToolTipIcon.Warning;
//                toolTipCaps.IsBalloon = true;
//                toolTipCaps.SetToolTip(passwordTextBox, "Having Caps Lock on may cause you to enter your password incorrectly.\n\nYou should press Caps Lock to turn it off before entering your password.");
//                toolTipCaps.Show("Having Caps Lock on may cause you to enter your password incorrectly.\n\nYou should press Caps Lock to turn it off before entering your password.", passwordTextBox, 5, passwordTextBox.Height - 5);
//            }
//        }
    }
}
