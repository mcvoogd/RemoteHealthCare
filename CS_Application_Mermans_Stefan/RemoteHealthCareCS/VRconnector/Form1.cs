using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRconnector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
<<<<<<< HEAD

            Connection connection = new Connection("84.24.41.72",6666);
            Console.WriteLine("Connecting: " + connection.StartConnection());
            
            connection.sendCommand();
=======
            Console.WriteLine("started.");
            Connection connection = new Connection("84.24.41.72", 6666);
            connection.StartConnection();
            Console.WriteLine("finished");

>>>>>>> 1071ffeda3a498f0f869f2ed1484c0be37d85a08
        }
    }
}
