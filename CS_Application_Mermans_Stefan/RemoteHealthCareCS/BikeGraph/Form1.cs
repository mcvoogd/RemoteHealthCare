using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeGraph
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort;
        private List<int> _graphInts;
        private int i = 0;

        public Form1()
        {
            InitializeComponent();
            
            _graphInts = new List<int>();
            _serialPort = new SerialPort("COM3");
            _serialPort.Open();

            graphicsPanel.Paint += new PaintEventHandler(graphThread);
            System.Threading.Thread thread = new Thread(multiThreading);
            thread.Start();
        }

        private void multiThreading()
        {
            while (true)
            {
                graphicsPanel.Invalidate();
            }
        }

        private void graphThread(object sender, PaintEventArgs eventArgs)
        {
           
            _serialPort.WriteLine("VS\r\n");
            try
            {   
                int temp;
                Int32.TryParse(_serialPort.ReadLine(), out temp);
                System.Console.WriteLine("CALL");

                Graphics graphics = eventArgs.Graphics;
                for (int ii = 0; ii < _graphInts.Count; ii++)
                {
                    graphics.DrawEllipse(new Pen(Color.Black), _graphInts[ii], i, temp, 10);
                }
                i ++;
                _graphInts.Add(temp);
            }
            catch (Exception)
            {
                
            }
            
        }

        
    }
}
