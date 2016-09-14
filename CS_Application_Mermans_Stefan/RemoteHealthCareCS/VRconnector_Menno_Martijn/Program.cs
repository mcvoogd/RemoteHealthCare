using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.IO;

namespace VRconnector_Menno_Martijn
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            TcpClient connector = new TcpClient();
            connector.Connect(IPAddress.Parse("84.24.41.72"), 1);
            //Console.WriteLine(connector.Connected);
            NetworkStream stream = connector.GetStream();

            //Packet toConnect = new Packet("session/list", null); later in the project this will be explained. For now leave it.
            String convertedPackage = JsonConvert.SerializeObject(new { id = "session/list" });
            //Console.WriteLine(convertedPackage);
            Byte[] length = BitConverter.GetBytes(convertedPackage.Length);
            stream.Write(length, 0, 4);

            Byte[] command = Encoding.UTF8.GetBytes(convertedPackage);
            stream.Write(command, 0, command.Length);

            //Works for the length just fine
            //byte[] buffer = new byte[4];
            //stream.Read(buffer, 0, 4);
            //Int32 lengthRecieved = BitConverter.ToInt32(buffer, 0);
            //Console.WriteLine(lengthRecieved);

            byte[] buffer = new byte[0];
            byte[] smallBuffer = new byte[500];
            while (true)
            {
                int read = stream.Read(smallBuffer, 0, 500);
                buffer = conCat(smallBuffer, buffer, read);
                if(buffer.Length >= 4)
                {
                    int packetLength = BitConverter.ToInt32(buffer, 0);
                    if(buffer.Length >= packetLength + 4)
                    {
                        readBuffer(buffer);
                    }
                }
                
            }
        }

        private byte[] conCat(byte[] smallBuffer, byte[] bigBuffer, int read)
        {
            byte[] conKitty = new byte[read + bigBuffer.Length];
            System.Buffer.BlockCopy(bigBuffer, 0, conKitty, 0, bigBuffer.Length);
            System.Buffer.BlockCopy(smallBuffer, 0, conKitty, bigBuffer.Length, read);
            return conKitty;
        }

        private void readBuffer(byte[] toRead)
        {
            byte[] response = SubArray(toRead, 4, toRead.Length - 4);
            String commandString = Encoding.UTF8.GetString(response);
            Console.WriteLine(commandString);
        }

        private byte[] SubArray(byte[] data, int idx, int length)
        {
            byte[] result = new byte[length];
            Array.Copy(data, idx, result, 0, length);
            return result;
        }
    }
}
