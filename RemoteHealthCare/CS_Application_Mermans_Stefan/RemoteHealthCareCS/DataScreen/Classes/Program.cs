using System;
using System.Windows.Forms;
using DataScreen.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new LoginForm();
            var dataWindow = new DataWindow();
            while (loginForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Application.Run(dataWindow);
        }
    }
}
