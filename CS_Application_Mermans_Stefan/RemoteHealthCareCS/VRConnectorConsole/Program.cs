﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRConnectorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection("84.24.41.72",6666);

            var thread = new Thread(connection.StartConnection);
            thread.Start();

            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
