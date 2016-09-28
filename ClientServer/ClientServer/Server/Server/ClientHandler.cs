using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Server.BigDB;
using Newtonsoft.Json;
using Server.TinyDB;

namespace Server.Server
{
    class ClientHandler
    {
        private readonly TcpClient _tcpClient;
        private readonly SslStream _sslStream;
//        private readonly Stream stream;

        private readonly BigDatabase _database;
        private Client _client = null;
        private byte[] _messageBuffer;

        private static X509Certificate2 serverCertificate = null;

        public ClientHandler(TcpClient tcpClient, BigDatabase databaseValue)
        {
            _tcpClient = tcpClient;
            _sslStream = new SslStream(_tcpClient.GetStream());
            this._database = databaseValue;
//            serverCertificate = new X509Certificate2(@"..\..\..\RemoteHealthCare.pfx", "password"); // not self-signed
            serverCertificate = new X509Certificate2(@"..\..\..\RemoteHealthCareSelfGenerated.pfx", "RemoteHealthCare");
                // Our own self signed cert with pasword

            _sslStream.AuthenticateAsServer(serverCertificate, false, SslProtocols.Tls, false);

            DisplaySecurityLevel(_sslStream);
            DisplaySecurityServices(_sslStream);
            DisplayCertificateInformation(_sslStream);
            DisplayStreamProperties(_sslStream);

            _messageBuffer = new byte[0];
        }

        //RECIEVER
        public void HandleClient()
        {
            Console.WriteLine("Handling client");
            var message = new byte[128];
            var sizeBuffer = new byte[0];
            while (_tcpClient.Connected)
            {
                try
                {
                    var numberOfBytesRead = _sslStream.Read(message, 0, message.Length);
                    _messageBuffer = ConCat(_messageBuffer, message, numberOfBytesRead);

                    if (_messageBuffer.Length <= 4) continue;
                    var packetLength = BitConverter.ToInt32(_messageBuffer, 0);

                    if (_messageBuffer.Length < packetLength + 4) continue;
                    var resultMessage = GetMessageFromBuffer(_messageBuffer, packetLength);
                    dynamic readMessage = JsonConvert.DeserializeObject(resultMessage);

                    var id = readMessage.id;
                    dynamic data = readMessage.data;

                    switch ((string) id)
                    {
                        case "message/send":
                            _client.TinyDataBaseBase.ChatSystem.AddMessage(ParseMessage(id));
                            SendAck("message/received");
                            break;

                        case "client/new":
                            //null == tunnelID. <VR>
                            //0 for self generate ID.
                            _client = new Client(data.username, data.password, null, 0, new TinyDataBase());
                            _database.AddClient(_client);
                            SendAck("client/new");
                            break;

                        case "measurement/add":
                            _client.TinyDataBaseBase.MeasurementSystem.AddMeasurement(ParseMeasurement(data));
                            Console.WriteLine($"Msrment added. <{_client.TinyDataBaseBase.MeasurementSystem.GetAllMeasurements().Count}>");
                            SendAck("measurement/add");
                            break;
                        case "login/request":
                            if (HandleLogin(data))
                            {
                                SendAck("login/request");
                                Console.WriteLine(_client.UniqueId + " <UNIQUE ID>");
                            }
                            else
                            {
                                SendNotAck("login/request");
                            }
                            break;
                        default:
                            Console.WriteLine("Id: " + id);
                            break;
                    }
                }
                catch (Exception e)
                {
                    if (!_tcpClient.Connected)
                    {
                        Console.WriteLine("Client disconnected.");
                    }
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        private void SendNotAck(string idV)
        {
            SendMessage(new
            {
                id = idV,
                data = new
                {
                    ack = false
                }
            });
        }

        public void SendAck(string idV)
        {
            SendMessage(new
            {
                id = idV,
                data = new
                {
                    ack = true
                }
            });
        }

        public void Disconnect()
        {
            SendMessage(new
            {
                id = "client/disconnect",
                data = new
                {
                    Disconnect = true
                }
            });
        }

        public void SendMessage(dynamic message)
        {
            if (_sslStream == null) return;
            message = JsonConvert.SerializeObject(message);
            var buffer = Encoding.Default.GetBytes(message);
            var bufferPrepend = BitConverter.GetBytes(buffer.Length);

            _sslStream.Write(bufferPrepend, 0, bufferPrepend.Length);
            _sslStream.Write(buffer, 0, buffer.Length);
        }

        public Measurement ParseMeasurement(dynamic data)
        {
            var tempString = (string) data.time;
            var temp = tempString.Split(':');

            SimpleTime tempTime;
            try
            {
                tempTime = new SimpleTime(int.Parse(temp[0]), int.Parse(temp[1]));
            }
            catch (Exception)
            {
                Console.WriteLine("parsing time fucks up!");
                tempTime = new SimpleTime(0,0);
            }

            try
            {
                var tempMeasurement = new Measurement(
                    (int)data.pulse,
                    (int)data.rotations,
                    (int)data.speed,
                    (int)data.power,
                    (double)data.distance,
                    (double)data.burned,
                    tempTime,
                    (int)data.reachedpower);

                return tempMeasurement;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: {0}\nStack trace: {1}", exception.ToString(), exception.StackTrace);
                return null;
            }
        }

        public Message ParseMessage(dynamic data)
        {
            var toSend = new Message(data.clientid, data.clientid, System.DateTime.Now, data.data.message);
            return toSend;
        }

        public bool HandleLogin(dynamic data)
        {
            string username = data.username;
            string password = data.password;
            int clientid = data.clientid;
            Console.WriteLine($"Name {username} | password {password} | clientid {clientid}");
            if (_database.GetClientById(clientid).Name.Equals("fout."))
            {
                //null == tunnelID. <VR>
//                _client = new Client(username, password, null, 0, new TinyDataBase());
//                _database.AddClient(_client);
                Console.WriteLine("Did not exist");
                return false;
            }
            _database.GetClientById(clientid, out _client);
            return true;
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
            _messageBuffer = newArray;

            return message.ToString();
        }

        #region Ssl security displays
        static void DisplaySecurityLevel(SslStream stream)
        {
            Console.WriteLine($"Cipher: {stream.CipherAlgorithm} strength {stream.CipherStrength}");
            Console.WriteLine($"Hash: {stream.HashAlgorithm} strength {stream.HashStrength}");
            Console.WriteLine($"Key exchange: {stream.KeyExchangeAlgorithm} strength {stream.KeyExchangeStrength}");
            Console.WriteLine($"Protocol: {stream.SslProtocol}");
        }
        static void DisplaySecurityServices(SslStream stream)
        {
            Console.WriteLine($"Is authenticated: {stream.IsAuthenticated} as server? {stream.IsServer}");
            Console.WriteLine($"IsSigned: {stream.IsSigned}");
            Console.WriteLine($"Is Encrypted: {stream.IsEncrypted}");
        }
        static void DisplayStreamProperties(SslStream stream)
        {
            Console.WriteLine($"Can read: {stream.CanRead}, write {stream.CanWrite}");
            Console.WriteLine($"Can timeout: {stream.CanTimeout}");
        }
        static void DisplayCertificateInformation(SslStream stream)
        {
            Console.WriteLine($"Certificate revocation list checked: {stream.CheckCertRevocationStatus}");

            X509Certificate localCertificate = stream.LocalCertificate;
            if (stream.LocalCertificate != null)
            {
                Console.WriteLine(
                    $"Local cert was issued to {localCertificate.Subject} and is valid from {localCertificate.GetEffectiveDateString()} " +
                    $"until {localCertificate.GetExpirationDateString()}.");
            }
            else
            {
                Console.WriteLine("Local certificate is null.");
            }
            // Display the properties of the client's certificate.
            X509Certificate remoteCertificate = stream.RemoteCertificate;
            if (stream.RemoteCertificate != null)
            {
                Console.WriteLine(
                    $"Remote cert was issued to {remoteCertificate.Subject} and is valid from " +
                    $"{remoteCertificate.GetEffectiveDateString()} until {remoteCertificate.GetExpirationDateString()}.");
            }
            else
            {
                Console.WriteLine("Remote certificate is null.");
            }
        }
        #endregion
    }
}
