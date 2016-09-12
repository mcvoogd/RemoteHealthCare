using System;
using System.Net.Sockets;
using System.Text;

namespace VRConnectorConsole
{
    class Connection
    {
        public string VRServerIP { get; set; }
        public int VRServerPort { get; set; }
        private TcpClient Client;
        public NetworkStream NetworkStream { get; set; }

        public Connection(string IP, int port)
        {
            this.VRServerIP = IP;
            this.VRServerPort = port;
        }

        public void stopConnection()
        {
            NetworkStream.Close();
            Client.Close();
        }

        public bool StartConnection()
        {
            try
            {
                Console.WriteLine("Connecting...");
                Client = new TcpClient(VRServerIP, VRServerPort);
                Console.WriteLine("Connected: " + Client.Connected);
                NetworkStream = Client.GetStream();
                NetworkStream.ReadTimeout = 1000;


                string request = "{'id' : 'session/list' }";

                byte[] buffer = Encoding.Default.GetBytes(request);

                NetworkStream.Write(buffer, 0, buffer.Length);

                StringBuilder message = new StringBuilder();
                int numberOfBytesRead = 0;
                byte[] receiveBuffer = new byte[4];

                do
                {
                    Console.WriteLine("loop");
                    numberOfBytesRead = NetworkStream.Read(receiveBuffer, 0, receiveBuffer.Length);
                    Console.WriteLine("read");
                    if (numberOfBytesRead <= 0)
                        break;
                    message.AppendFormat("{0}", Encoding.ASCII.GetString(receiveBuffer, 0, numberOfBytesRead));

                } while (Client.Connected);

                Console.WriteLine("response");
                string response = message.ToString();
                Console.WriteLine(response);
            }
            catch (Exception)
            {
                Console.WriteLine("Error while connecting");
            }
            return Client.Connected;
        }

        public bool IsConnected()
        {
            return Client != null ? Client.Connected : Client.Connected;
        }
    }
}
