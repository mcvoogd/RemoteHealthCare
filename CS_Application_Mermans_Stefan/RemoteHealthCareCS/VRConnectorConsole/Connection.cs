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

//        public void stopConnection()
//        {
//            NetworkStream.Close();
//            Client.Close();
//        }

        public void StartConnection()
        {
            try
            {
                Console.WriteLine("Connecting...");
                Client = new TcpClient(VRServerIP, VRServerPort);
                Console.WriteLine("Connected: " + Client.Connected);
                NetworkStream = Client.GetStream();

                string request = "{\"id\" : \"session/list\"}";

                byte[] buffer = Encoding.Default.GetBytes(request);
                byte[] bufferPrepend = BitConverter.GetBytes(buffer.Length);

                NetworkStream.Write(bufferPrepend,0,bufferPrepend.Length);
                NetworkStream.Write(buffer, 0, buffer.Length);

                StringBuilder message = new StringBuilder();
                int numberOfBytesRead = 0;
                byte[] receiveBuffer = new byte[1024];

                do
                {
                    Console.WriteLine("loop");
                    numberOfBytesRead = NetworkStream.Read(receiveBuffer, 0, receiveBuffer.Length);
                    Console.WriteLine("numberofBytes:" + numberOfBytesRead);
                    if (numberOfBytesRead <= 0)
                        break;
                    message.AppendFormat("{0}", Encoding.ASCII.GetString(receiveBuffer, 0, numberOfBytesRead));
                    Console.WriteLine("response");
                    string response = message.ToString();
                    Console.WriteLine(response);

                } while (Client.Connected);

                
            }
            catch (Exception)
            {
                Console.WriteLine("Error while connecting");
            }
        }

        public bool IsConnected()
        {
            return Client != null ? Client.Connected : Client.Connected;
        }
    }
}
