using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;

namespace Server.Server
{
    class ClientHandler
    {
        private TcpClient _client;
        private SslStream _sslStream;

        private byte[] _messageBuffer;

        private static X509Certificate2 serverCertificate = null;

        public ClientHandler(TcpClient tcpClient)
        {
            _client = tcpClient;
            _sslStream = new SslStream(_client.GetStream());

            serverCertificate = new X509Certificate2(@"..\..\..\RemoteHealthCare.pfx", "RemoteHealthCare");

            _sslStream.AuthenticateAsServer(serverCertificate,false,SslProtocols.Tls,false);

            DisplaySecurityLevel(_sslStream);
            DisplaySecurityServices(_sslStream);
            DisplayCertificateInformation(_sslStream);
            DisplayStreamProperties(_sslStream);

            _messageBuffer = new byte[0];
        }

        public void HandleClient()
        {
            Console.WriteLine("Handling client");

            var message = new byte[128];
            var sizeBuffer = new byte[4];

            while (_client.Connected)
            {
                var buffer = new byte[] {1, 2, 3, 4};
                _sslStream.Write(buffer);
                _sslStream.Flush();
//                var numberOfBytesRead = _sslStream.Read(message, 0, message.Length);
//                _messageBuffer = ConCat(_messageBuffer, message, numberOfBytesRead);
//
//                if (message.Length < 4) continue;
//                var packetLength = BitConverter.ToInt32(message, 0);
//
//                if (message.Length < packetLength + 4) continue;
//                var resultMessage = GetMessageFromBuffer(message, packetLength);
//
//                dynamic readMessage = JsonConvert.DeserializeObject(resultMessage);

                // TODO receive messages from the client
                //                throw new NotImplementedException();
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
        private static string GetMessageFromBuffer(byte[] array, int count)
        {
            var message = new StringBuilder();
            message.AppendFormat("{0}", Encoding.ASCII.GetString(array, 4, count));
            return message.ToString();
        }

        #region Ssl security displays
        static void DisplaySecurityLevel(SslStream stream)
        {
            Console.WriteLine("Cipher: {0} strength {1}", stream.CipherAlgorithm, stream.CipherStrength);
            Console.WriteLine("Hash: {0} strength {1}", stream.HashAlgorithm, stream.HashStrength);
            Console.WriteLine("Key exchange: {0} strength {1}", stream.KeyExchangeAlgorithm, stream.KeyExchangeStrength);
            Console.WriteLine("Protocol: {0}", stream.SslProtocol);
        }
        static void DisplaySecurityServices(SslStream stream)
        {
            Console.WriteLine("Is authenticated: {0} as server? {1}", stream.IsAuthenticated, stream.IsServer);
            Console.WriteLine("IsSigned: {0}", stream.IsSigned);
            Console.WriteLine("Is Encrypted: {0}", stream.IsEncrypted);
        }
        static void DisplayStreamProperties(SslStream stream)
        {
            Console.WriteLine("Can read: {0}, write {1}", stream.CanRead, stream.CanWrite);
            Console.WriteLine("Can timeout: {0}", stream.CanTimeout);
        }
        static void DisplayCertificateInformation(SslStream stream)
        {
            Console.WriteLine("Certificate revocation list checked: {0}", stream.CheckCertRevocationStatus);

            X509Certificate localCertificate = stream.LocalCertificate;
            if (stream.LocalCertificate != null)
            {
                Console.WriteLine("Local cert was issued to {0} and is valid from {1} until {2}.",
                    localCertificate.Subject,
                    localCertificate.GetEffectiveDateString(),
                    localCertificate.GetExpirationDateString());
            }
            else
            {
                Console.WriteLine("Local certificate is null.");
            }
            // Display the properties of the client's certificate.
            X509Certificate remoteCertificate = stream.RemoteCertificate;
            if (stream.RemoteCertificate != null)
            {
                Console.WriteLine("Remote cert was issued to {0} and is valid from {1} until {2}.",
                    remoteCertificate.Subject,
                    remoteCertificate.GetEffectiveDateString(),
                    remoteCertificate.GetExpirationDateString());
            }
            else
            {
                Console.WriteLine("Remote certificate is null.");
            }
        }
        #endregion
    }
}
