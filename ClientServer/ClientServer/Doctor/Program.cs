using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Connection;
using DataScreen.Forms;

namespace Doctor
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

            var mainForm = new mainForm { Visible = false };
            var connector = new Connector();
            var loginForm = new LoginForm(connector.Connect, mainForm);

            Application.Run(loginForm);
        }
    }
}
