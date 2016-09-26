using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms
{
    public delegate void SendMessage(dynamic message);


    public partial class RemoteHealthcare : Form
    {
        private readonly SendMessage _sendMessage;
        private readonly string _connectionId;
        private string _message;

        public RemoteHealthcare(SendMessage sendMessage, string connectionId)
        {
            _sendMessage = sendMessage;
            _connectionId = connectionId;
            _message = null;
            InitializeComponent();
            this.Paint += RemoteHealthcare_Paint;
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

        private void RemoteHealthcare_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("PAINT");
            if (_message != null)
            {
                Console.WriteLine("message: " + _message);
                chatTextBox.Text += _message + "\n";
                _message = null;
            }
        }
    }
}
