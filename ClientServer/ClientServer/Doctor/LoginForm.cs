using System;
using System.Threading;
using System.Windows.Forms;

namespace DataScreen.Forms
{
    public delegate bool Connect(string serverIp, string username, string password);
    public partial class LoginForm : Form
    {
        private Connect _connect;

        public LoginForm(Connect connect)
        {
            this.FormClosing += LoginForm_FormClosing;
            InitializeComponent();
            _connect = connect;
            //passwordTextBox.MouseHover += new EventHandler(passwordTextBox_MouseHover);
            //passwordTextBox.MouseLeave += new EventHandler(passwordTextBox_MouseLeave);
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
                Console.WriteLine("USERNAME: " + usernameTextBox.Text);
            } else
            {
                wrongLogin.Visible = true;
            }
            
            //            wrongLogin.Visible = true;
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
