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

        public Connection(string IP, int port)
        {
            this.VRServerIP = IP;
            this.VRServerPort = port;
         
        }

        public Boolean StartConnection()
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

        public Boolean IsConnected()
        {
            return Client != null ? Client.Connected : Client.Connected;
        }
    }
}
