using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
using SysTimer = System.Timers.Timer;

using System.Timers;
using System.Windows.Forms;

namespace Client.Forms
{
    public delegate void SendMessage(dynamic message);

    public partial class RemoteHealthcare : Form
    {
        private readonly SendMessage _sendMessage;
        private readonly int _connectionId;
        private string _message;

        public RemoteHealthcare(SendMessage sendMessage, int connectionId)
        {
            _sendMessage = sendMessage;
            _connectionId = connectionId;
            _message = null;
            InitializeComponent();
        }

        public void Message(string message)
        {
            Console.WriteLine("GUI Message");
            _message = message;
            Invalidate();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            _sendMessage(new
            {
                id = "Message/send",
                clientid = _connectionId,
                data = new
                {
                    message = messageTextBox.Text
                }
            });
            messageTextBox.Text = "";
        }
    }
}
