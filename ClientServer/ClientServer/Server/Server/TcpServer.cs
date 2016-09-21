using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Server.BigDB;

namespace Server.Server
{
    public class TcpServer
    {
        private readonly TcpListener _tcpListener;
        private readonly BigDatabase _dataBase = new BigDatabase();
        public IPAddress IpAddress { get; set; }

        public TcpServer()
        {
            IpAddress = GetLocalIpAddress();
            _tcpListener = new TcpListener(IpAddress,6969);
            Console.WriteLine("IpAddress: {0}",IpAddress);
        }

        public void Run()
        {
            Console.WriteLine("Starting server...");
            _tcpListener.Start();

            while (true)
            {
                try
                {
                    var tcpClientTask = _tcpListener.AcceptTcpClientAsync();
                    var tcpClient = tcpClientTask.Result;
                    Console.WriteLine("Connected to a client");
                    
                    var clienthandler = new ClientHandler(tcpClient, _dataBase);
                    Console.WriteLine("Clienthandler");
                    var clientHandlerThread = new Thread(clienthandler.HandleClient);
                    Console.WriteLine("Starting thread...");
                    clientHandlerThread.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Exception!");
                }
            }
        }

        public static IPAddress GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}
