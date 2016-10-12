using System;
using System.Threading;
using Server.BigDB;
using Server.Server;
using Server.TinyDB;

namespace Server
{
    internal class Program
    {
        private TcpServer _tcpServer;

        private static void Main(string[] args)
        {
            var program = new Program();
        }

        public Program()
        {
            _tcpServer = new TcpServer();

            var serverThread = new Thread(_tcpServer.Run);
            serverThread.Start();

            Console.WriteLine($"Type 'Help' to show available commands.");
            ConsoleLoop();

            // Constantly check user input for the exit command.
            // Properly close the program by stopping all threads.
            // It may in the future be better to properly disconnect the clients before just interrupting the server.
            foreach (var clientHandleThread in _tcpServer.threads)
            {
                clientHandleThread.Interrupt();
                clientHandleThread.Abort();
            }
            foreach (var clientHandler in TcpServer.ClientHandlers)
                clientHandler.Disconnect();

            _tcpServer.SaveAllData();
            serverThread.Interrupt();
            serverThread.Abort();

            // Environment.Exit(0);
        }

        private void ConsoleLoop()
        {
            while (true)
            {
                switch (Console.ReadLine()?.ToLower())
                {
                    case "exit":
                        return;
                    case "newdoctor":
                        CreateUser(true);
                        break;
                    case "newpatient":
                        CreateUser(false);
                        break;
                    case "deleteuser":
                        DeleteUser();
                        break;
                    case "help":
                        Console.WriteLine("Commands :\n- exit\n- newdoctor\n- newpatient\n- deleteuser\n- showclients\n- help");
                        break;
                    case "showclients":
                        ShowUsers();
                        break; 
                    default:
                        Console.WriteLine("Command not recognised...");
                        break;
                }
            }
        }

        private void ShowUsers()
        {
            foreach (var client in _tcpServer.DataBase.Clients)
            {
                Console.WriteLine(client);
            }
        }

        private void DeleteUser()
        {
            Console.WriteLine("Deleting user...\nEnter a name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();
            var id = Client.GetUniqueId(name, password);

            Console.WriteLine("Removing user...");
            if (_tcpServer.DataBase.Clients.Remove(_tcpServer.DataBase.GetClientById(id)))
            {
                Console.WriteLine("Done!");
            }
            else
            {
                Console.WriteLine("ERR: Removing Failed!");
            }
        }

        private int GetDoctorId()
        {
            var doctorid = 0;

            Console.WriteLine("Enter the id of the corresponding doctor:");
            var succes = int.TryParse(Console.ReadLine(), out doctorid);
            if (succes)
            {
                foreach (var databaseClient in _tcpServer.DataBase.Clients)
                {
                    if (databaseClient.IsDoctor && databaseClient.UniqueId == doctorid)
                    {
                        return doctorid;
                    }
                }
            }
            while (true)
            {
                Console.WriteLine("Inavlid doctor id, continue?(y/n):");
                var answer = Console.ReadLine().ToLower();
                if (answer == "y") return 0;
                if (answer == "n") return -1;
            }
        }

        private void CreateUser(bool doctor)
        {
            var passwords = new string[2];
            var doctorid = 0;

            Console.WriteLine("new user...\nEnter a name: ");
            var name = Console.ReadLine();
            if (!doctor)
            {
                while (true)
                {
                    doctorid = GetDoctorId();
                    if (doctorid == -1)
                    {
                        Console.WriteLine("Cancelling...");
                        return;
                    }
                    if (doctorid != 0)
                    {
                        break;
                    }
                }
            }
            while (true)
            {
                Console.WriteLine("Enter a password:");
                passwords[0] = Console.ReadLine();
                Console.WriteLine("Re-enter password:");
                passwords[1] = Console.ReadLine();
                if (passwords[0] == passwords[1]) break;
            }
            var client = new Client(name,passwords[0],null,0,new TinyDataBase(), doctor,doctorid,false);//set online state to false.
            _tcpServer.DataBase.AddClient(client);
            Console.WriteLine("User created...");
        }
    }
}