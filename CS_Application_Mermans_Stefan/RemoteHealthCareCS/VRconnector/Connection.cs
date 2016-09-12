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

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public void sendCommand()
        {
            string data = "{'id' : 'session/list'}";

            Client.GetStream();
            Client.Client.Send(GetBytes(data));

            byte[] buffer = new byte[27];
            Console.WriteLine("Receiving");
            Client.Client.Receive(buffer);
            Console.WriteLine(buffer);
        }

        public bool StartConnection()
        {
            try
            {
                Client = new TcpClient(VRServerIP, VRServerPort);
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
