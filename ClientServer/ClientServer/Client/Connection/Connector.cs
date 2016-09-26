using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client.Connection
{
    class Connector
    {
        private SslStream _sslStream;
        private TcpClient _tcpClient;

//        private NetworkStream _stream;
        private string _connectionId;
        private byte[] messageBuffer = new byte[0];

        public Connector()
        {
            _sslStream = null;
            _connectionId = null;
        }

        public void receiver()
        {
            var message = new byte[128];
            var sizeBuffer = new byte[4];

            try
            {
                while (_tcpClient.Connected)
                {
                    try
                    {
                        var numberOfBytesRead = _sslStream.Read(message, 0, message.Length);
                        messageBuffer = ConCat(messageBuffer, message, numberOfBytesRead);

                        if (messageBuffer.Length <= 4) continue;
                        var packetLength = BitConverter.ToInt32(messageBuffer, 0);

                        if (messageBuffer.Length < packetLength + 4) continue;

                        var resultMessage = GetMessageFromBuffer(messageBuffer, packetLength);
                        dynamic readMessage = JsonConvert.DeserializeObject(resultMessage);
                        Console.WriteLine("Read: " + resultMessage);

                        if (readMessage == null)
                        {
                        }
                        else
                        {
                            string id = readMessage.id;
                            dynamic data = readMessage.data;

                            switch (id)
                            {
                                case "login/request":
                                    Console.WriteLine("Login/request");
                                    Thread sendStatistics = new Thread(this.SendStatistics);
                                    sendStatistics.Start();
                                    break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        if (!_tcpClient.Connected)
                        {
                            Console.WriteLine("Client disconnected.");
                        }
                    }
                }
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }
                Console.WriteLine("Authentication failed - closing the connection.");
                _tcpClient.Close();
                return;
            }
        }

        public void Connect(string serverIp, string username, string password)
        {
            _tcpClient = new TcpClient(serverIp,6969);
            _sslStream = new SslStream(_tcpClient.GetStream(),false, new RemoteCertificateValidationCallback(ValidateServerCertificate),null);
            _sslStream.AuthenticateAsClient(_tcpClient.Client.AddressFamily.ToString());
            Login(username, password);
        }

        public void SendStatistics()
        {
            while (true)
            {
                SendMessage(new
                {
                    id = "measurement/add",
                    clientid = _connectionId,
                    data = new
                    {
                        pulse = "80",
                        rotations = "130",
                        speed = "35",
                        distance = "1.23",
                        power = "45",
                        burned = "23.4",
                        time = "09.12",
                        reachedpower = "30"
                    }
                });
            }
        }

        private void Login(string username, string password)
        {
            if (_sslStream == null) return;

            _connectionId = CalcXor(username, password);

            SendMessage(new
            {
                id = "login/request",
                data = new
                {
                    username,
                    clientid = _connectionId,
                    password
                }
            });
        }

        public string CalcXor(string a, string b)
        {
            var charAArray = a.ToCharArray();
            var charBArray = b.ToCharArray();
            var result = new char[6];
            var len = 0;

            // Set length to be the length of the shorter string
            if (a.Length > b.Length)
                len = b.Length - 1;
            else
                len = a.Length - 1;

            for (int i = 0; i < len; i++)
            {
                result[i] = (char) (charAArray[i] ^ charBArray[i]);
            }

          //  Console.WriteLine("Xor: " + new string(result));
            return a + b;
        }

        public void SendMessage(dynamic message)
        {
            while (!_sslStream.CanWrite)
            {
                Console.WriteLine("Can write: {0}",_sslStream.CanWrite);
                
            }
            if(_sslStream == null) return;

            message = JsonConvert.SerializeObject(message);
            var buffer = Encoding.Default.GetBytes(message);
            var bufferPrepend = BitConverter.GetBytes(buffer.Length);

            _sslStream.Write(bufferPrepend, 0, bufferPrepend.Length);
            _sslStream.Write(buffer, 0, buffer.Length);
            _sslStream.Flush();
        }


        // Currently always returns true...
        public static bool ValidateServerCertificate(
             object sender,
             X509Certificate certificate,
             X509Chain chain,
             SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return true;
        }

        // Gets the first message from the buffer that isn't idicating the size
        private string GetMessageFromBuffer(byte[] array, int count)
        {
            var newArray = new byte[array.Length - (count + 4)];

            var message = new StringBuilder();
            message.AppendFormat("{0}", Encoding.ASCII.GetString(array, 4, count));

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i + count + 4];
            }
            messageBuffer = newArray;

            return message.ToString();
        }

        // Combine two byte arrays into one.
        // count amount of bytes to copy from the second arrays
        private static byte[] ConCat(byte[] arrayOne, byte[] arrayTwo, int count)
        {
            var newArray = new byte[arrayOne.Length + count];
            System.Buffer.BlockCopy(arrayOne, 0, newArray, 0, arrayOne.Length);
            System.Buffer.BlockCopy(arrayTwo, 0, newArray, arrayOne.Length, count);
            return newArray;
        }
    }
}
