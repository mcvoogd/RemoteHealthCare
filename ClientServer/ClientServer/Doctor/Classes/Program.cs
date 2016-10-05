using System;
using System.Windows.Forms;
using Doctor.Forms;

namespace Doctor.Classes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm { Visible = false };
            var connector = new DoctorConnector();
            var loginForm = new LoginForm(connector.Connect, mainForm);

            Application.Run(loginForm);
        }
        }

    }

