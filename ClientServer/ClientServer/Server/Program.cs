using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server.BigDB;
using Server.Server;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //TcpServer tcpServer = new TcpServer();

            //var serverThread = new Thread(tcpServer.Run);
            //serverThread.Start();
            //Thread.Sleep(100); // Wait 100 ms before display the stop command to make it look a bit better.
            //Console.WriteLine("Type 'Exit' anytime to stop the server...");
            //while (Console.ReadLine()?.ToLower() != "exit"){} // Constantly check user input for the exit command.

            //// Properly close the program by stopping all threads.
            //// It may in the future be better to properly disconnect the clients before just interrupting the server.
            //serverThread.Interrupt();
            //serverThread.Abort();

            BigDatabase testBase = new BigDatabase();
            testBase.AddClient(new Client("Henk1", "0001", "1000", null));
            testBase.AddClient(new Client("Henk2", "0002", "2000", null));
            testBase.AddClient(new Client("Henk3", "0003", "3000", null));
            testBase.AddClient(new Client("Henk4", "0004", "4000", null));

            testBase.SaveClientRegister("C:/Users/Menno/Documents/clientlist/clientregister.txt", testBase.Clients);
            Console.WriteLine("Wrote everything, now reading");
            testBase.LoadClientRegister("C:/Users/Menno/Documents/clientlist/clientregister.txt");
            Console.WriteLine("Done");
        }
    }
}
