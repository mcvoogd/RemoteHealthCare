using System;
using System.IO.Ports;
using DataScreen.Forms;

namespace DataScreen.Classes
{
    class DataReceiver
    {
        private readonly SerialPort _serialPort;
        private readonly DataWindow _dataWindow;

        public DataReceiver(SerialPort serialPort, DataWindow dataWindow)
        {
            _dataWindow = dataWindow;
            _serialPort = serialPort;
        }

        public void Run()
        {
            while (_serialPort != null && _serialPort.IsOpen && _dataWindow.Visible)
            {
                try
                {

                    _serialPort.WriteLine(Program.StatusCommand);
                    Console.WriteLine("Reading...");
                    string temp = _serialPort.ReadLine();

                    _dataWindow.DataList.Add(temp);
                    _dataWindow.SetText(temp);
                }
                catch (Exception exception)
                {
                    //TODO handle exception
                }
                
            }
        }

        public static string SendCommand(string command, SerialPort serialPort)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine(command);
                return serialPort.ReadLine();
            }
            else
            {
                Console.WriteLine("Failed to send command");
                return null;
            }
        }

        public static string ReceiveCommand(SerialPort serialPort)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                return serialPort.ReadLine();
            }
            return null;
        }
    }
}
