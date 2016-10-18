using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Server.BigDB;

namespace Server.Server
{
    public class TcpServer
    {
        public static List<ClientHandler> ClientHandlers = new List<ClientHandler>();
        public readonly BigDatabase DataBase = new BigDatabase();
        private readonly TcpListener _tcpListener;

        public List<Thread> threads = new List<Thread>();
        public string SavePath { get; set; }

        public TcpServer()
        {
            IpAddress = GetLocalIpAddress();
            _tcpListener = new TcpListener(IpAddress, 6969);
            Console.WriteLine("IpAddress: {0}", IpAddress);

            SavePath = $@"{Directory.GetCurrentDirectory()}\ClientData\Clients.save";
            if (!Directory.Exists($@"{Directory.GetCurrentDirectory()}\ClientData\"))
                Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\ClientData\");

            SetSavePath();
            Console.WriteLine($"SavePath = {SavePath}");
            Console.WriteLine($"Current dir: {Directory.GetCurrentDirectory()}");

            LoadAllData();
        }

        [Conditional("DEBUG")]
        private void SetSavePath()
        {
            SavePath = @"..\..\ClientData\Clients.save";
        }

        public IPAddress IpAddress { get; set; }

        public void Run()
        {
            Console.WriteLine("Starting server...");
            _tcpListener.Start();

            while (true)
                try
                {
                    var tcpClientTask = _tcpListener.AcceptTcpClientAsync();
                    var tcpClient = tcpClientTask.Result;
                    Console.WriteLine("Connected to a client");

                    var clienthandler = new ClientHandler(tcpClient, DataBase);
                    ClientHandlers.Add(clienthandler);

                    Console.WriteLine("Clienthandler");
                    var clientHandlerThread = new Thread(clienthandler.HandleClient);
                    Console.WriteLine("Starting thread...");
                    clientHandlerThread.Start();
                    threads.Add(clientHandlerThread);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Exception!");
                }
        }

        public void SaveAllData()
        {
            string path = SavePath;
            DataBase.SaveClients(path);
        }

        public void LoadAllData()
        {
            string path = SavePath;
            if (File.Exists(path))
            {
                if (File.Exists(path))
                {
                    DataBase.LoadClients(path);
                    Console.WriteLine("Loaded ClientData.");
                    foreach (var client in DataBase.Clients)
                    {
                        Console.WriteLine(client.ToString());   
                    }
                }
            }
            else
            {
                Console.WriteLine("Nothing loaded, no file found.");
            }

            foreach (var Client in DataBase.Clients)
            {
                Client.IsOnline = false;
            }
        }

        public static IPAddress GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip;
            throw new Exception("Local IP Address Not Found!");
        }

        public static ClientHandler GetClientHandlerByClientID(int clientId)
        {
            return ClientHandlers.FirstOrDefault(clientHandler => clientHandler.Client.UniqueId == clientId);
        }
    }
}