using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Simulation
{
    public partial class DataWindow : Form, StandardErgometer
    {
        public SerialPort SerialPort { get; set; }
        public string SelectedComm { get; set; }
        private string[] _portStrings;
        public List<string> DataList { get; set; }

        public DataWindow()
        {
            InitializeComponent();

            DataList = new List<string>();

            _portStrings = SerialPort.GetPortNames();
            for (int i = 0; i < _portStrings.Length; i++)
            {
                comboBox1.Items.Add(_portStrings[i]);
            }
        }

        delegate void SetTextCallback(string text);

        public void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (dataTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
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
            if (SerialPort == null || !SerialPort.IsOpen)
            {
                if (SelectedComm != null)
                {
                    SerialPort = new SerialPort(SelectedComm);
                    SerialPort.Open();

                    DataReceiver dataReceiver = new DataReceiver(SerialPort,this);
                    System.Threading.Thread dataReceiverThread = new Thread(dataReceiver.Run);
                    dataReceiverThread.Start();
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
            if (SerialPort == null || !SerialPort.IsOpen)
            {
                Console.WriteLine("Not connected");
            }
            else
            {
                SerialPort.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedComm = (string) comboBox1.SelectedItem;
        }

        private void controlPanelButton_Click(object sender, EventArgs e)
        {
            new ControlPanel();
        }

        public void connect()
        {
            throw new NotImplementedException();
        }

        public void disconnect()
        {
            throw new NotImplementedException();
        }

        public int pulse
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int rotations
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int speed
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int power
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int burned
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int time
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int reachedpower
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int distance
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
