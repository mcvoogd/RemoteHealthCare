using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            var RemoteHealthcare = new RemoteHealthcare();
            RemoteHealthcare.Visible = false;
            var LoginForm = new LoginForm(RemoteHealthcare);
            Application.Run(LoginForm);


        }
    }
}
