using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using Server.BigDB;

namespace Server.Server
{
    public class TcpServer
    {
        private readonly TcpListener _tcpListener;
        private readonly BigDatabase _dataBase = new BigDatabase();
        public IPAddress IpAddress { get; set; }
        public List<Thread> threads = new List<Thread>();
        public static List<ClientHandler> ClientHandlers = new List<ClientHandler>();

        public TcpServer()
        {
            IpAddress = GetLocalIpAddress();
            _tcpListener = new TcpListener(IpAddress,6969);
            Console.WriteLine("IpAddress: {0}",IpAddress);
            LoadAllData();
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
                    ClientHandlers.Add(clienthandler);

                    Console.WriteLine("Clienthandler");
                    var clientHandlerThread = new Thread(clienthandler.HandleClient);
                    Console.WriteLine("Starting thread...");
                    clientHandlerThread.Start();
                    threads.Add(clientHandlerThread);
                }
                catch (Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Exception!");
                 
                }
            }
        }

        public void SaveAllData()
        {
            const string path = @"..\..\ClientData\file.txt";
            _dataBase.SaveClients(path);
        }

        public void LoadAllData()
        {
            const string path = @"..\..\ClientData\file.txt";
            if (File.Exists(path))
            {
                if (File.Exists(path))
                {
                    _dataBase.LoadClients(path);
                    Console.WriteLine("Loaded ClientData.");
                }
            }
            else
            {
                Console.WriteLine("Nothing loaded, no file found.");
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

        public static ClientHandler GetClientHandlerByClientID(int clientId)
        {
            return ClientHandlers.FirstOrDefault(clientHandler => clientHandler.Client.UniqueId == clientId);
        }
    }
}
