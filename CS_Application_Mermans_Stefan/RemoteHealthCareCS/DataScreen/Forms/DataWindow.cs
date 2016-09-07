﻿using DataScreen.Classes;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace DataScreen.Forms
{
    public partial class DataWindow : Form, IStandardErgometer
    {
        private const string SimulatorText = "Simulator";

        public SerialPort SerialPort { get; set; }
        public string SelectedComm { get; set; }
        public string[] PortStrings { get; }
        public List<string> DataList { get; set; }

        public int Pulse { get; set; }
        public int Rotations { get; set; }
        public int Speed { get; set; }
        public int Power { get; set; }
        public int Burned { get; set; }
        public int Time { get; set; }
        public int Reachedpower { get; set; }
        public int Distance { get; set; }

        public DataWindow()
        {
            InitializeComponent();

            DataList = new List<string>();

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
            if (SerialPort == null || !SerialPort.IsOpen)
            {
                if (SelectedComm != null)
                {
                    if (SelectedComm == SimulatorText)
                    {
                        new SimulationForm().Show();
                    }
                    else
                    {
                        SerialPort = new SerialPort(SelectedComm);
                        SerialPort.Open();

                        // Try to activate the command untill confirmation is received. DANGEROUS!
                        while (DataReceiver.SendCommand(Program.ActivateCommands, SerialPort) != "RUN") { }

                        var dataReceiver = new DataReceiver(SerialPort, this);
                        var dataReceiverThread = new Thread(dataReceiver.Run);
                        dataReceiverThread.Start();
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

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}