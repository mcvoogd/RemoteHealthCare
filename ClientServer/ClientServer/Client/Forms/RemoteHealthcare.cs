using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using Client.Connection;
using Client.Simulator;
using DataScreen.Forms;
using Message = Client.Connection.Message;

namespace Client.Forms
{
    public delegate void SendMessage(dynamic message);

    public delegate void AddMessage(string message);

    public delegate void SendStatistics(Measurement measurement);

    public partial class RemoteHealthcare : Form
    {
        private readonly AddMessage _addMessage;
        private readonly List<Message> _messages = new List<Message>();
        private readonly SendMessage _sendMessage;
        private readonly SendStatistics _sendStatistics;
        private string _message;

        public RemoteHealthcare(SendMessage sendMessage, SendStatistics sendStatistics, int connectionId)
        {
            _sendMessage = sendMessage;
            _sendStatistics = sendStatistics;
            _addMessage = AddMessageMethod;


            FormClosing += RemoteHealthCare_FormClosing;
            ConnectionId = connectionId;
            _message = null;
            InitializeComponent();
            Paint += RemoteHealthcare_Paint;
            Measurements = new List<Measurement>();

            PortStrings = SerialPort.GetPortNames();
            foreach (var port in PortStrings)
                comportBox.Items.Add(port);
            comportBox.Items.Add("Simulation");

            connectStatusLabel.Text = "Connected";
            timer1.Start();
        }

        public string name { get; set; }

        public int ConnectionId { get; set; }
        public string[] PortStrings { get; }
        public DataReceiver DataReceiver { get; set; }
        public List<Measurement> Measurements { get; set; }

        public void AddMessageMethod(string message)
        {
            chatTextBox.Text += message;
        }

        public void Message(string message)
        {
            Console.WriteLine("GUI Message");
            if (InvokeRequired)
                Invoke(_addMessage, message);
            else
                chatTextBox.Text += message;
        }

        public void AddMessage(Message msg)
        {
            _messages.Add(msg);
            // RefreshMessageList();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            _sendMessage(new
            {
                id = "message/send",
                clientid = ConnectionId,
                data = new
                {
                    message = messageTextBox.Text += "\n"
                }
            });
            chatTextBox.Text += messageTextBox.Text;
            messageTextBox.Text = "";
        }

        private void RemoteHealthcare_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("PAINT");
            usernameLabel.Text = name;
        }

        private void RemoteHealthCare_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _sendMessage(new
                    {
                        id = "client/disconnect",
                        data = new
                        {
                            Disonnect = true
                        }
                    });
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

        private void comPortConnectButton_Click(object sender, EventArgs e)
        {
            if (comportBox.SelectedItem?.ToString() == "Simulation")
            {
                var simulationForm = new SimulationForm();

                DataReceiver = new DataReceiver(this, simulationForm, AddMeasurement);
                var dataReceiverThread = new Thread(DataReceiver.Run);
                dataReceiverThread.Start();
            }
            else if (comportBox.SelectedItem != null)
            {
                var serialPort = new SerialPort(comportBox.SelectedItem.ToString());
                serialPort.Open();
                DataReceiver = new DataReceiver(serialPort, this, AddMeasurement);
                var dataReceiverThread = new Thread(DataReceiver.Run);
                dataReceiverThread.Start();
            }
        }

        public void AddMeasurement(Measurement measurement)
        {
            Measurements.Add(measurement);
            _sendStatistics(measurement);
        }


        public void RefreshMessageList()
        {
            chatTextBox.Text = "";
            foreach (var message in _messages)
            {
                chatTextBox.Text += message.MessageValue;
                chatTextBox.Text += "\n";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Measurements.Count <= 0) return;
            chart1.Series[0].Points.Add(Measurements[Measurements.Count - 1].Speed);
        }
    }
}