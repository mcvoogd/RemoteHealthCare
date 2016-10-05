using System;
using System.Windows.Forms;
using Client.Connection;
using Client.Forms;

namespace Client.Forms
{
    public delegate bool Connect(string serverIp, string username, string password, RemoteHealthcare remoteHealthcare);

    public partial class LoginForm : Form
    {
        private readonly Connect _connect;
        private readonly RemoteHealthcare RemoteHealthcare;

        public LoginForm(RemoteHealthcare RemoteHealthcare, Connect connect)
        {
            FormClosing += LoginForm_FormClosing;
            InitializeComponent();
            this.RemoteHealthcare = RemoteHealthcare;
            _connect = connect;
            //passwordTextBox.MouseHover += new EventHandler(passwordTextBox_MouseHover);
            //passwordTextBox.MouseLeave += new EventHandler(passwordTextBox_MouseLeave);
        }


        private static void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    Environment.Exit(0);
                else
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (_connect(severIpTextBox.Text, usernameTextBox.Text, passwordTextBox.Text, RemoteHealthcare))
            {
                Visible = false;
                RemoteHealthcare.Visible = true;
                RemoteHealthcare.name = usernameTextBox.Text;
                Console.WriteLine("USERNAME: " + usernameTextBox.Text);
                RemoteHealthcare.Invalidate();
            }
            else
            {
                wrongLogin.Visible = true;
            }

            //            wrongLogin.Visible = true;
        }

//        }
//            toolTipCaps.Hide(passwordTextBox);
//        {
//        void passwordTextBox_MouseLeave(object sender, EventArgs e)

//        ToolTip toolTipCaps = new ToolTip();
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