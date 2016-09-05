using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataScreen
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

                    _serialPort.WriteLine(Program.STATUS_COMMAND);
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
    }
}
