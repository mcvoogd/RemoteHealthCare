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

namespace RemoteHealthCareCS
{
    public partial class Form1 : Form
    {
        public static string COMMAND_RESET = "RS\r\n";
        public static string COMMAND_GET_ID = "ID\r\n";
        public static string COMMAND_GET_VER = "VE\r\n";
        public static string COMMAND_COMMAND_MODE = "CM\r\n";
        public static string COMMAND_STATUS = "ST\r\n";
        public static string COMMAND_RMP = "VS\r\n";

        private string[] _portStrings;
        private List<int> _rpmInts = new List<int>();
        private SerialPort _serialPort;

        public Form1()
        {
            InitializeComponent();
            panel1.Paint += new PaintEventHandler(panel1_Paint);            

            _serialPort = null;
            _portStrings = SerialPort.GetPortNames();

            for (int i = 0; i < _portStrings.Length; i++)
            {
                comboBox1.Items.Add(_portStrings[i]);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            Graphics graphics = e.Graphics;

            if(_rpmInts != null && _rpmInts.Count > 0)
            {
                for (int i = 0; i < _rpmInts.Count; i++)
                {
                    graphics.DrawRectangle(new Pen(Color.Aqua),new Rectangle(i,_rpmInts[i],10,10) );
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.WriteLine(COMMAND_RESET);
                textBox1.Text += _serialPort.ReadLine() + "\n";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _serialPort = new SerialPort((string) comboBox1.SelectedItem);
                _serialPort.Open();
                textBox1.Text += "Connected\n";
            }
            catch (Exception exception)
            {
                System.Console.WriteLine("Connection failed");
                // TODO do something with this exception
            }
        }

        private void IDButton_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.WriteLine(COMMAND_GET_ID);
                textBox1.Text += _serialPort.ReadLine() + "\n";
            }
        }

        private void versionButton_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.WriteLine(COMMAND_GET_VER);
                textBox1.Text += _serialPort.ReadLine() + "\n";
            }
        }

        private void commandMButton_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.WriteLine(COMMAND_COMMAND_MODE);
                textBox1.Text += _serialPort.ReadLine() + "\n";
            }
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.WriteLine(COMMAND_STATUS);
                textBox1.Text += _serialPort.ReadLine() + "\n";
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                textBox1.Text += "Disconnected\n";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
