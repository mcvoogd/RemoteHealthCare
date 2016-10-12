using System;
using System.Windows.Forms;
using Client.Connection;
using Client.Forms;
using Client.VRConnection.Forms.Program;

namespace Client
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

            var connector = new Connector();
            var remoteHealthcare = new RemoteHealthcare(connector.SendMessage, connector.SendStatistics,
                connector.ConnectionId);
            var loginForm = new LoginForm(remoteHealthcare, connector.Connect);

            Application.Run(loginForm);

            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }
    }
}