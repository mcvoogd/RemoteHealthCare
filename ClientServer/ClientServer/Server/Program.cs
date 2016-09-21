using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BigDB;
using Server.Server;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpServer tcpServer = new TcpServer();
            
            
            var serverThread = new Thread(tcpServer.Run);
            serverThread.Start();

            Thread.Sleep(100); // Wait 100 ms before display the stop command to make it look a bit better.
            Console.WriteLine("Type 'Exit' anytime to stop the server...");
            while (Console.ReadLine()?.ToLower() != "exit"){} // Constantly check user input for the exit command.

            // Properly close the program by stopping all threads.
            // It may in the future be better to properly disconnect the clients before just interrupting the server.
            serverThread.Interrupt();
            serverThread.Abort();
        }
    }
}
