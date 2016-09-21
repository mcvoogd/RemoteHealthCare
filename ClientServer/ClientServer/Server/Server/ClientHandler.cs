using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using BigDB;
using Newtonsoft.Json;
using Server.TinyDB;

namespace Server.Server
{
    class ClientHandler
    {
        private readonly TcpClient _tcpClient;
        private readonly SslStream _sslStream;
        private readonly Stream stream;

        private readonly BigDatabase _database;
        private Client _client = null;
        private byte[] _messageBuffer;

        private static X509Certificate2 serverCertificate = null;

        public ClientHandler(TcpClient tcpClient, BigDatabase databaseValue)
        {
            _tcpClient = tcpClient;
            //_sslStream = new SslStream(_tcpClient.GetStream());
            stream = _tcpClient.GetStream();
            this._database = databaseValue;
//            serverCertificate = new X509Certificate2(@"..\..\..\RemoteHealthCare.pfx", "RemoteHealthCare");
//
//            _sslStream.AuthenticateAsServer(serverCertificate,false,SslProtocols.Tls,false);
//
//            DisplaySecurityLevel(_sslStream);
//            DisplaySecurityServices(_sslStream);
//            DisplayCertificateInformation(_sslStream);
//            DisplayStreamProperties(_sslStream);

            _messageBuffer = new byte[0];
        }

        public void HandleClient()
        {
            Console.WriteLine("Handling client");
            var message = new byte[128];
            var sizeBuffer = new byte[0];

            while (_tcpClient.Connected)
            {
                 try
                {
                    var numberOfBytesRead = stream.Read(message, 0, message.Length);
                    _messageBuffer = ConCat(_messageBuffer, message, numberOfBytesRead);

                    if (_messageBuffer.Length <= 4) continue;
                    var packetLength = BitConverter.ToInt32(_messageBuffer, 0);

                    if (_messageBuffer.Length < packetLength + 4) continue;
                    var resultMessage = GetMessageFromBuffer(_messageBuffer, packetLength);
                    dynamic readMessage = JsonConvert.DeserializeObject(resultMessage);
                    //Console.WriteLine(readMessage.ToString());
                    if (readMessage == null)
                    {
                        Console.WriteLine("Readmessage = null.");
                        Console.WriteLine("Length: " + packetLength);
                        Console.WriteLine("Data: '" + resultMessage + "'");
                    }
                    else
                    {
                        string id = readMessage.id;
                        dynamic data = readMessage.data;

                        switch (id)
                        {
                            case "measurement/add":
                                _client.TinyDataBaseBase.AddMeasurement(ParseMeasurement(data));
                                Console.WriteLine("Added measurement!");
                                break;
                            case "login/request":
                                Console.WriteLine("LOGINGEN!");
                                HandleLogin(data);
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("hoi..");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
          }
        }

        public Measurement ParseMeasurement(dynamic inputString)
        {
            string stringholder = inputString;
            inputString = inputString.Trim();
            string[] splitString = inputString.Split(new char[0]);
            var simpleTimeString = splitString[6].Split(':');

            splitString[6] = "0";
            var lijstje = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var teller = 0;
            foreach (var s in splitString)
            {
                lijstje[teller] = int.Parse(s);
                teller++;
            }

            var tempTime = new SimpleTime(int.Parse(simpleTimeString[0]), int.Parse(simpleTimeString[1]));
            var tempMeasurement = new Measurement(lijstje[0], lijstje[1], lijstje[2], lijstje[3], lijstje[4], lijstje[5], tempTime, lijstje[7], stringholder);

            return tempMeasurement;
        }

        public void HandleLogin(dynamic data)
        {
            string username = data.username;
            string password = data.password;
            string clientid = data.clientid;
            Console.WriteLine($"Username : {username}, \nPassword : {password}, \nID : {clientid}");
            if (!_database.GetClientById(clientid).name.Equals("fout."))
            {
                Console.WriteLine("Found existing");
                _database.GetClientById(clientid, out _client);
            }
            else
            {
                _client = new Client(username, null, clientid, new TinyDataBase());
                Console.WriteLine($"Created client : {username} ,\n{clientid}");
                _database.AddClient(_client);
            }
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
