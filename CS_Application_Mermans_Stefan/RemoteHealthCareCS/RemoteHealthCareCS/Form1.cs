using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteHealthCareCS
{
    public partial class Form1 : Form
    {
        public static string COMMAND_RESET = "RS";
        public static string COMMAND_GET_ID = "ID";
        public static string COMMAND_GET_VER = "VE";
        public static string COMMAND_COMMAND_MODE = "CM";
        public static string COMMAND_STATUS = "ST";

        private string[] _portStrings;
        private SerialPort _serialPort;

        public Form1()
        {
            InitializeComponent();

            _serialPort = null;
            _portStrings = SerialPort.GetPortNames();

            for (int i = 0; i < _portStrings.Length; i++)
            {
                comboBox1.Items.Add(_portStrings[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.WriteLine(COMMAND_RESET);
                textBox1.Text += _serialPort.ReadLine();
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
                textBox1.Text += _serialPort.ReadLine();
            }
        }

        private void versionButton_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.WriteLine(COMMAND_GET_VER);
                textBox1.Text += _serialPort.ReadLine();
            }
        }

        private void commandMButton_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.WriteLine(COMMAND_COMMAND_MODE);
                textBox1.Text += _serialPort.ReadLine();
            }
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.WriteLine(COMMAND_STATUS);
                textBox1.Text += _serialPort.ReadLine();
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
