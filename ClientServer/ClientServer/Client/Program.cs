using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Connection;
using Client.Forms;
using DataScreen.Forms;

namespace Client
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

            var connector = new Connector();
            var remoteHealthcare = new RemoteHealthcare(connector.SendMessage, connector.ConnectionId) {Visible = false};
            var loginForm = new LoginForm(remoteHealthcare,connector.Connect);

            Application.Run(loginForm);
        }
    }
}
