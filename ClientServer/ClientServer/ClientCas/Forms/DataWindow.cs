using ClientCas.Classes;
using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace DataScreen.Forms
{
    public partial class DataWindow : Form
    {
        private const string SimulatorText = "Simulator";

        public SerialPort SerialPort { get; set; }
        public string SelectedComm { get; set; }
        public string[] PortStrings { get; }
        public bool Connected { get; set; }
        private readonly SimulationForm _simulationForm;
        private System.Threading.Thread _receiverThread;

        public DataWindow()
        {
            _simulationForm = new SimulationForm();
            _receiverThread = null;
            Connected = false;
            InitializeComponent();

            PortStrings = SerialPort.GetPortNames();
            foreach (string port in PortStrings)
            {
                comboBox1.Items.Add(port);
            }
            comboBox1.Items.Add(SimulatorText);
        }

        private delegate void SetTextCallback(string text);

        public void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (dataTextBox.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.dataTextBox.AppendText(text);
                dataTextBox.SelectionStart = dataTextBox.TextLength;
                dataTextBox.ScrollToCaret();
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if ((SerialPort == null || !SerialPort.IsOpen) && !Connected)
            {
                if (SelectedComm != null)
                {
                    if (SelectedComm == SimulatorText)
                    {
                        var dataReceiver = new DataReceiver(this,_simulationForm);
                        _receiverThread = new Thread(dataReceiver.Run);

                        _receiverThread.Start();
                        Connected = true;
                        _simulationForm.Show();

                        statusLabel.Text = "Simulating";
                    }
                    else
                    {
                        SerialPort = new SerialPort(SelectedComm);
                        SerialPort.Open();

                        // Try to activate the command untill confirmation is received. DANGEROUS!
//                        while (DataReceiver.SendCommand(Program.ActivateCommands, SerialPort) != "RUN") { }
//                        DataReceiver.SendCommand(Program.ResetCommand, SerialPort);
                        //DataReceiver.SendCommand(Program.ActivateCommands, SerialPort);

                        var dataReceiver = new DataReceiver(SerialPort, this);
                        _receiverThread = new Thread(dataReceiver.Run);
                        _receiverThread.Start();
                        Connected = true;
                        statusLabel.Text = $"Verbonden met: {SerialPort.PortName}";
                    }
                }
                else
                {
                    Console.WriteLine("Selected comport is invalid");
                }
            }
            else
            {
                Console.WriteLine($"Already connected to: {SerialPort.GetPortNames()}");
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (Connected)
            {
                if ((SerialPort == null || !SerialPort.IsOpen) && _receiverThread != null)
                {
                    _receiverThread.Abort();
                    _receiverThread = null;
                    Connected = false;
                    statusLabel.Text = "niet verbonden";
                }
                else
                {
                    SerialPort.Close();
                    Connected = false;
                    statusLabel.Text = "niet verbonden";
                }
            }
            else
            {
                Console.WriteLine("Not connected");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedComm = (string) comboBox1.SelectedItem;
        }
    }
}