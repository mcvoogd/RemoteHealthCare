using System;
using System.IO.Ports;
using System.Threading;
using Client.Forms;
using Client.Simulator;
using DataScreen.Forms;

namespace Client.Connection
{
    public delegate void AddMeasurement(Measurement measurement);

    public class DataReceiver
    {
        private readonly RemoteHealthcare _remoteHealthcare;
        private readonly SerialPort _serialPort;
        private readonly SimulationForm _simulation;
        private readonly AddMeasurement _addMeasurement;

        public DataReceiver(SerialPort serialPort, RemoteHealthcare remoteHealthcare, AddMeasurement addMeasurement)
        {
            _remoteHealthcare = remoteHealthcare;
            _serialPort = serialPort;
            _simulation = null;
            _addMeasurement = addMeasurement;
            SendCommand("RS\n\r", serialPort);
        }

        public DataReceiver(RemoteHealthcare remoteHealthcare, SimulationForm simulation, AddMeasurement addMeasurement)
        {
            _remoteHealthcare = remoteHealthcare;
            _serialPort = null;
            _simulation = simulation;
            _addMeasurement = addMeasurement;
        }

        public void Run()
        {
            while (_remoteHealthcare.Visible)
            {
                if (_simulation != null)
                {
                    if (!_simulation.Visible) return;

                    _addMeasurement(_simulation.Measurement);

                    Thread.Sleep(1000);
                    _simulation.UpdateSim();
                }
                else if ((_serialPort != null) && _serialPort.IsOpen)
                {
                    try
                    {
                        //Changed the write and read line to send and receive command
                        Console.WriteLine("Sending");
                        SendCommand("ST\r\n", _serialPort);

                        Console.WriteLine("Reading...");
                        var temp = ReceiveCommand(_serialPort);

                        _addMeasurement(ParseMeasurement(temp));
      
                        Thread.Sleep(1000);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine($"Exception! : {exception.StackTrace}");
                    }
                }
            }
        }

        public static void SendCommand(string command, SerialPort serialPort)
        {
            if ((serialPort != null) && serialPort.IsOpen)
                serialPort.WriteLine(command);
            else
                Console.WriteLine("Failed to send command");
        }

        public static string ReceiveCommand(SerialPort serialPort)
        {
            if ((serialPort != null) && serialPort.IsOpen)
                return serialPort.ReadLine();
            return null;
        }

        public static Measurement ParseMeasurement(string inputString)
        {
            inputString = inputString.Trim();
            var splitString = inputString.Split();
            var simpleTimeString = splitString[6].Split(':');

            splitString[6] = "0";
            int[] list = {0, 0, 0, 0, 0, 0, 0, 0, 0};
            var index = 0;
            foreach (var s in splitString)
            {
                list[index] = int.Parse(s);
                index++;
            }

            var tempTime = new SimpleTime(int.Parse(simpleTimeString[0]), int.Parse(simpleTimeString[1]));
            var tempMeasurement = new Measurement(list[0], list[1], list[2]/10, list[4], list[3], list[5],
                tempTime.Minutes, tempTime.Seconds, list[7]);

            return tempMeasurement;
        }

        public SerialPort GetSerialPort()
        {
            return _serialPort;
        }
    }
}