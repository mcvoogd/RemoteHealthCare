using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using Client.Forms;
using Client.Simulator;
using DataScreen.Forms;

namespace Client.Connection
{
    class DataReceiver
    {
        private readonly SerialPort _serialPort;
        private readonly RemoteHealthcare _remoteHealthcare;
        private readonly SimulationForm _simulation;
        public readonly List<Measurement> Measurements;

        public DataReceiver(SerialPort serialPort, RemoteHealthcare remoteHealthcare)
        {
            _remoteHealthcare = remoteHealthcare;
            _serialPort = serialPort;
            Measurements = new List<Measurement>();
            _simulation = null;
        }

        public DataReceiver(RemoteHealthcare remoteHealthcare, SimulationForm simulation)
        {
            _remoteHealthcare = remoteHealthcare;
            _serialPort = null;
            Measurements = new List<Measurement>();
            _simulation = simulation;
        }

        public void Run()
        {
            while (_remoteHealthcare.Visible)
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    try
                    {
                        Console.WriteLine("Sending");
                        _serialPort.WriteLine("ST\r\n");
                        Console.WriteLine("Reading...");
                        var temp = _serialPort.ReadLine();

                        Measurements.Add(ParseMeasurement(temp));

                        //RemoteHealthcare.SetText(temp);
                    }
                    catch (Exception)
                    {
                        //TODO handle exception
                    }
                }
                else
                {
                    Measurements.Add(_simulation.Measurement);
                    
//                    _remoteHealthcare.SetText(
//                    $"{_simulation.Measurement.Pulse}\t" +
//                    $"{_simulation.Measurement.Rotations}\t" +
//                    $"{_simulation.Measurement.Speed}\t" +
//                    $"{(int)_simulation.Measurement.Distance}\t" +
//                    $"{_simulation.Measurement.Power}\t     " +
//                    $"{(int)_simulation.Measurement.Burned}\t   " +
//                    $"{_simulation.Measurement.Time}\t " +
//                    $"{_simulation.Measurement.ReachedPower}\n");

                    Thread.Sleep(1000);
                    _simulation.updateSim();
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