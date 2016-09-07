using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using DataScreen.Forms;

namespace DataScreen.Classes
{
    class DataReceiver
    {
        private readonly SerialPort _serialPort;
        private readonly DataWindow _dataWindow;
        private SimulationForm _simulation;
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
                        string temp = _serialPort.ReadLine();

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
                    Measurements.Add(_simulation.measurement);
                    
                    _dataWindow.SetText(
                    $"{_simulation.measurement.Pulse}   " +
                    $"{_simulation.measurement.Rotations}   " +
                    $"{_simulation.measurement.Speed}   " +
                    $"{_simulation.measurement.Distance}   " +
                    $"{_simulation.measurement.Power}   " +
                    $"{_simulation.measurement.Burned}   " +
                    $"{_simulation.measurement.Time}   " +
                    $"{_simulation.measurement.ReachedPower}\n");

                    Thread.Sleep(1000);
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
            string stringholder = inputString;
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
            
            Measurement tempMeasurement = new Measurement(lijstje[0], lijstje[1], lijstje[2], lijstje[3], lijstje[4], lijstje[5], tempTime, lijstje[7], stringholder);

            return tempMeasurement;
        }
    }
}
