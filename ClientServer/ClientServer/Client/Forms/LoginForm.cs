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
                var result = MessageBox.Show("Wil je afsluiten?", "Afsluiten", MessageBoxButtons.YesNo);
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
        }
    }
}