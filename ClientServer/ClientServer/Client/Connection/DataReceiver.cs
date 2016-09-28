using System;
using System.Collections.Generic;
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
        private readonly SerialPort _serialPort;
        private readonly RemoteHealthcare _remoteHealthcare;
        private readonly SimulationForm _simulation;
        private AddMeasurement _addMeasurement;

        public DataReceiver(SerialPort serialPort, RemoteHealthcare remoteHealthcare, AddMeasurement addMeasurement)
        {
            _remoteHealthcare = remoteHealthcare;
            _serialPort = serialPort;
            _simulation = null;
            _addMeasurement = addMeasurement;
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
                Console.WriteLine("Looping");
                if (_simulation != null)
                {
                    _addMeasurement(_simulation.Measurement);

                    Thread.Sleep(1000);
                    Console.WriteLine("updating sim");
                    _simulation.updateSim();
                } else if (_serialPort != null && _serialPort.IsOpen)
                {
                    try
                    {
                        Console.WriteLine("Sending");
                        _serialPort.WriteLine("ST\r\n");
                        Console.WriteLine("Reading...");
                        var temp = _serialPort.ReadLine();

                        _addMeasurement(ParseMeasurement(temp));

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

        public static Measurement ParseMeasurement(string inputString)
        {
            string stringholder = inputString;
            inputString = inputString.Trim();
            string[] splitString = inputString.Split(new char[0]);
            string[] simpleTimeString = splitString[6].Split(':');
            
            splitString[6] = "0";
            //splitString[8] = "0";
            int[] lijstje = new[] {0, 0, 0, 0, 0, 0, 0, 0, 0};
            int teller = 0;
            foreach (string s in splitString)
            {
                lijstje[teller] = int.Parse(s);
                teller++;
            }

            var tempTime = new SimpleTime(int.Parse(simpleTimeString[0]), int.Parse(simpleTimeString[1]));
            var tempMeasurement = new Measurement(lijstje[0], lijstje[1], lijstje[2], lijstje[3], lijstje[4], lijstje[5], tempTime, lijstje[7]);

            return tempMeasurement;
        }
    }
}