using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRConnectorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection("84.24.41.72",6666);
            connection.StartConnection();

            Console.Read();
            connection.stopConnection();
        }
    }
}
