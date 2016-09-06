using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataScreen
{
    static class Program
    {
        public const string STATUS_COMMAND = "ST";
        public const string ACTIVATE_COMMANDS = "CM";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            DataWindow dataScreen;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(dataScreen = new DataWindow());


        }
    }
}
