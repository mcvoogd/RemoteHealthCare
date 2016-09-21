using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using DataScreen.Forms;
using static ClientCas.Classes.Measurement;

namespace ClientCas.Classes
{
    class DataReceiver
    {
        private readonly SerialPort _serialPort;
        private readonly DataWindow _dataWindow;
        private readonly SimulationForm _simulation;
        public readonly List<Measurement> Measurements;

        public DataReceiver(SerialPort serialPort, DataWindow dataWindow)
        {
            _dataWindow = dataWindow;
            _serialPort = serialPort;
            Measurements = new List<Measurement>();
            _simulation = null;
        }

        public DataReceiver(DataWindow dataWindow, SimulationForm simulation)
        {
            _dataWindow = dataWindow;
            _serialPort = null;
            Measurements = new List<Measurement>();
            _simulation = simulation;
        }

        public void Run()
        {
            while (_dataWindow.Connected && _dataWindow.Visible)
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    try
                    {
                        Console.WriteLine("Sending");
                        _serialPort.WriteLine(Program.StatusCommand);
                        Console.WriteLine("Reading...");
                        var temp = _serialPort.ReadLine();

                        Measurements.Add(ParseMeasurement(temp));

                        _dataWindow.SetText(temp);
                    }
                    catch (Exception)
                    {
                        //TODO handle exception
                    }
                }
                else
                {
                    Measurements.Add(_simulation.Measurement);
                    
                    _dataWindow.SetText(
                    $"{_simulation.Measurement.Pulse}\t" +
                    $"{_simulation.Measurement.Rotations}\t" +
                    $"{_simulation.Measurement.Speed}\t" +
                    $"{(int)_simulation.Measurement.Distance}\t" +
                    $"{_simulation.Measurement.Power}\t     " +
                    $"{(int)_simulation.Measurement.Burned}\t   " +
                    $"{_simulation.Measurement.Time}\t " +
                    $"{_simulation.Measurement.ReachedPower}\n");

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
            var tempMeasurement = new Measurement(lijstje[0], lijstje[1], lijstje[2], lijstje[3], lijstje[4], lijstje[5], tempTime, lijstje[7], stringholder);

            return tempMeasurement;
        }
    }
}
