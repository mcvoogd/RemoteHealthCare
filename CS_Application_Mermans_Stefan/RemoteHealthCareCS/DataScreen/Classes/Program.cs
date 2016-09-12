using System;
using System.Windows.Forms;
using DataScreen.Forms;
using System.Collections.Generic;

namespace DataScreen.Classes
{
    static class Program
    {
        public const string StatusCommand = "ST";
        public const string ActivateCommands = "CM";
        public const string ResetCommand = "RS";
        public const string test = "Pw(10000)";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //var loginForm = new LoginForm();
            //var dataWindow = new DataWindow();
            //while (loginForm.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}
            //Application.Run(dataWindow);

            List<Measurement> measurements = new List<Measurement>();
            measurements.Add(new Measurement(105, 10, 40, 75, 135, new SimpleTime(50, 10), 165, 195));
            measurements.Add(new Measurement(110, 15, 50, 80, 140, new SimpleTime(50, 15), 170, 200));
            measurements.Add(new Measurement(115, 20, 55, 85, 145, new SimpleTime(50, 20), 175, 205));
            measurements.Add(new Measurement(120, 25, 60, 90, 150, new SimpleTime(50, 25), 180, 210));
            measurements.Add(new Measurement(125, 30, 65, 95, 155, new SimpleTime(50, 30), 185, 215));
            measurements.Add(new Measurement(130, 35, 70, 100, 160, new SimpleTime(50, 35), 190, 220));

            DrawMeasurements drawMeasurements = new DrawMeasurements(measurements);
            drawMeasurements.drawPulse(DrawMeasurements.Graph.BARGRAPH);
        }
    }
}
