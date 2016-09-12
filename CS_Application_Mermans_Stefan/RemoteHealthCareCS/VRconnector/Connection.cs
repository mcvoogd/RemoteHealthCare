using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VRconnector
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

        public bool StartConnection()
        {
            try
            {
                Client = new TcpClient(VRServerIP, VRServerPort);
                NetworkStream = Client.GetStream();

                string request = "{'id' : 'session/list' }";

                byte[] buffer = Encoding.Default.GetBytes(request);
                
                NetworkStream.Write(buffer, 0, buffer.Length);

                StringBuilder message = new StringBuilder();
                int numberOfBytesRead = 0;
                byte[] receiveBuffer = new byte[1024];

                do
                {
                    numberOfBytesRead = NetworkStream.Read(receiveBuffer, 0, receiveBuffer.Length);
                    if (numberOfBytesRead <= 0)
                        break;
                    message.AppendFormat("{0}", Encoding.ASCII.GetString(receiveBuffer, 0, numberOfBytesRead));

                } while (Client.Connected);


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
