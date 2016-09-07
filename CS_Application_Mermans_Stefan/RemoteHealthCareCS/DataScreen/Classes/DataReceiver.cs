using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using DataScreen.Forms;

namespace DataScreen.Classes
{
    class DataReceiver
    {
        private readonly SerialPort _serialPort;
        private readonly DataWindow _dataWindow;
        public readonly List<Measurement> Measurements;

        public DataReceiver(SerialPort serialPort, DataWindow dataWindow)
        {
            _dataWindow = dataWindow;
            _serialPort = serialPort;
            Measurements = new List<Measurement>();
        }

        public void Run()
        {
            while (_serialPort != null && _serialPort.IsOpen && _dataWindow.Visible)
            {
                try
                {
                    Console.WriteLine("Sending");
                    _serialPort.WriteLine(Program.StatusCommand);
                    Console.WriteLine("Reading...");
                    string temp = _serialPort.ReadLine();
                    
                    Measurements.Add(ParseMeasurement(temp));

                    _dataWindow.DataList.Add(temp);
                    _dataWindow.SetText(temp);
                }
                catch (Exception exception)
                {
                    //TODO handle exception
                }
                
            }
        }

        public static void SendCommand(string command, SerialPort serialPort)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine(command);
            }
            else
            {
                Console.WriteLine("Failed to send command");
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

        public static Measurement ParseMeasurement(String inputString)
        {
            inputString.Trim();
            string[] splitString = inputString.Split(new char[0]);
            string[] simpleTimeString = splitString[6].Split(':');
            
            splitString[6] = "0";
            splitString[8] = "0";
            int[] lijstje = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0};
            int teller = 0;
            foreach (String s in splitString)
            {
                lijstje[teller] = Int32.Parse(s);
                teller++;
            }

            SimpleTime tempTime = new SimpleTime(Int32.Parse(simpleTimeString[0]), Int32.Parse(simpleTimeString[1]));
            
            Measurement tempMeasurement = new Measurement(lijstje[0], lijstje[1], lijstje[2], lijstje[3], lijstje[4], lijstje[5], tempTime, lijstje[7]);

            return tempMeasurement;
        }
    }
}
