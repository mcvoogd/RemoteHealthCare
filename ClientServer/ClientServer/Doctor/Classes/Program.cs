using System;
using System.Windows.Forms;
using Doctor.Forms;

namespace Doctor.Classes
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var connector = new DoctorConnector();
            var mainForm = new MainForm(connector.SetCurrentPatient, connector.SendMessage, connector.GetAllPatients, connector.GetAllMeasurements, connector) {Visible = false};
            var loginForm = new LoginForm(connector.Connect, mainForm);

            Application.Run(loginForm);
            Application.Exit();
        }
    }
}