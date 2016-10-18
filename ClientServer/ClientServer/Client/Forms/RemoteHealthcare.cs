using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Client.Connection;
using Client.Simulator;
using Client.VRConnection.Forms.Program;
using DataScreen.Forms;
using Message = Client.Connection.Message;
using Timer = System.Timers.Timer;
using System.Runtime.InteropServices;
using Client.Properties;
using System.Drawing.Text;
using System.Drawing;

namespace Client.Forms
{
    public delegate void SendMessage(dynamic message);

    public delegate void AddMessage(string message);

    public delegate void SendStatistics(Measurement measurement);

    public delegate void RefreshMessageDelegate();

    public partial class RemoteHealthcare : Form
    {
        private readonly AddMessage _addMessage;
        private readonly List<Message> _messages = new List<Message>();
        private readonly SendMessage _sendMessage;
        private readonly SendStatistics _sendStatistics;
        private readonly RefreshMessageDelegate _refreshMessage;

        private FontFamily _goodTimes;

        public Form1 Form1 { get; set; }

        public RemoteHealthcare(SendMessage sendMessage, SendStatistics sendStatistics, int connectionId)
        {
            _sendMessage = sendMessage;
            _sendStatistics = sendStatistics;
            _addMessage = AddMessageMethod;
            _refreshMessage = RefreshMessageList;

            FormClosing += RemoteHealthCare_FormClosing;
            ConnectionId = connectionId;
            InitializeComponent();
            Paint += RemoteHealthcare_Paint;
            Measurements = new List<Measurement>();

            CargoPrivateFontCollection();
            Fonts();

            PortStrings = SerialPort.GetPortNames();
            foreach (var port in PortStrings)
                comportBox.Items.Add(port);
            comportBox.Items.Add("Simulation");
            connectStatusLabel.ForeColor = Color.Green;
            connectStatusLabel.Text = "Connected";
            timer1.Start();
        }

        public string name { get; set; }

        public int ConnectionId { get; set; }
        public string[] PortStrings { get; }
        public DataReceiver DataReceiver { get; set; }
        public List<Measurement> Measurements { get; set; }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private void CargoPrivateFontCollection()
        {
            // Create the byte array and get its length

            var fontArray = Resources.good_times;
            var dataLength = Resources.good_times.Length;

            // ASSIGN MEMORY AND COPY  BYTE[] ON THAT MEMORY ADDRESS
            var ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            var pfc = new PrivateFontCollection();
            //PASS THE FONT TO THE  PRIVATEFONTCOLLECTION OBJECT
            pfc.AddMemoryFont(ptrData, dataLength);

            //FREE THE  "UNSAFE" MEMORY
            Marshal.FreeCoTaskMem(ptrData);

            _goodTimes = pfc.Families[0];
        }

        private void Fonts()
        {
            connectStatusLabel.Font = new Font(_goodTimes, 10.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameLabel.Font = new Font(_goodTimes, 10.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Font = new Font(_goodTimes, 15F, FontStyle.Regular | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Font = new Font(_goodTimes, 10.25F, FontStyle.Regular | FontStyle.Regular, GraphicsUnit.Point, 0);
            comPortConnectButton.Font = new Font(_goodTimes, 7.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sendButton.Font = new Font(_goodTimes, 5.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

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
            Invoke(_refreshMessage);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            _sendMessage(new
            {
                id = "message/send",
                data = new
                {
                    message = messageTextBox.Text,
                    originid = ConnectionId,
                    name = usernameLabel.Text,
                    targetid = 0 // the destination is determined in the server
                }
            });
            chatTextBox.Text += $"{DateTime.Now:t}--{usernameLabel.Text}: {messageTextBox.Text}\n";
            AddMessage(new Message(0,ConnectionId,DateTime.Now,usernameLabel.Text,messageTextBox.Text));
            messageTextBox.Text = "";
        }

        private void RemoteHealthcare_Paint(object sender, PaintEventArgs e)
        {
            usernameLabel.Text = name;
        }

        private void RemoteHealthCare_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Wil je afsluiten?", "Afsluiten", MessageBoxButtons.YesNo);
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
                    Environment.Exit(1);
                    Application.Exit();
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
                
                Form1 = new Form1();

                var dataReceiverThread = new Thread(DataReceiver.Run);
                dataReceiverThread.Start();
                Form1.Visible = true;
                Form1.Invalidate();
            }
            else if (comportBox.SelectedItem != null)
            {
                var serialPort = new SerialPort(comportBox.SelectedItem.ToString());
                serialPort.Open();
                DataReceiver = new DataReceiver(serialPort, this, AddMeasurement);
                Form1 = new Form1();

                var dataReceiverThread = new Thread(DataReceiver.Run);
                dataReceiverThread.Start();
                Form1.Visible = true;
                Form1.Invalidate();
            }
        }

        public void AddMeasurement(Measurement measurement)
        {
            Measurements.Add(measurement);
            _sendStatistics(measurement);

            if (Form1.Tunnel == null || Form1.Tunnel.Panel == null) return;
            Form1.Tunnel.DrawPanel(measurement.BackSlashNToString());

           // Form1.Tunnel.UpdateSpeed(measurement.Speed);
        }


        public void RefreshMessageList()
        {
            chatTextBox.Text = "";
            foreach (var message in _messages)
            {
                if (message.Sender == ConnectionId)
                {
                    chatTextBox.Text += $"\n{message.Time:t}--{name}: {message.MessageValue}";
                }
                else
                {
                    chatTextBox.Text += $"\n{message.Time:t}--{message.Name}: {message.MessageValue}";
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(DataReceiver == null) return;
            if (!DataReceiver.Simulation.Visible) return;
            if (Measurements.Count <= 0) return;
            chart1.Series[0].Points.Add(Measurements[Measurements.Count - 1].Speed);
        }

        public void SendCommandToBike(dynamic message)
        {
            //TODO unpack list of commands into a usable list
            //TODO send with delay
            //TODO does this even work, no really
            List<dynamic> steps = message.data;
            int control = steps.Count;

            for (int j = 0; j < control; j++)
            {
                SerialPort port = DataReceiver.GetSerialPort();
                Console.WriteLine("HELLO, NOW RECEIVING");
                DataReceiver.SendCommand("CM", port);
                DataReceiver.SendCommand($"PW{steps[j].resistance}", port);
                Delay(steps[j]);
                //waitTimer.Interval = Double.Parse(steps[j].duration);
            }
        }

        private void Delay(int delay)
        {
            Timer t = new Timer();
            t.Interval = delay * 1000;
            t.Elapsed += (s, e) =>
            {
                //a();
                Console.WriteLine("DELAY DONE");
                t.Stop();
            };
            t.Start();
            //TODO add a method for the list shenenigans
        }
    }
}