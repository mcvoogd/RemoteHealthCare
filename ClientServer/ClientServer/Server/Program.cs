using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.Connection;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpServer tcpServer = new TcpServer();

            var serverThread = new Thread(tcpServer.Run);
            serverThread.Start();

            Thread.Sleep(1000);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            serverThread.Interrupt();
            serverThread.Abort();
        }
    }
}
