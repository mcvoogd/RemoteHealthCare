﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server.Connection
{
    class ClientHandler
    {
        private TcpClient _client;
        private SslStream _sslStream;

        private byte[] _messageBuffer;

        private static X509Certificate serverCertificate = null;

        public ClientHandler(TcpClient tcpClient)
        {
            _client = tcpClient;
            _sslStream = new SslStream(_client.GetStream());

            serverCertificate = X509Certificate.CreateFromCertFile(@"..\..\..\CSR.cr");

            _sslStream.AuthenticateAsServer(serverCertificate);

            _messageBuffer = new byte[0];
        }

        public void HandleClient()
        {
            Console.WriteLine("Handling client");

            var message = new byte[128];
            var sizeBuffer = new byte[4];

            while (_client.Connected)
            {
                var numberOfBytesRead = _sslStream.Read(message, 0, message.Length);
                _messageBuffer = ConCat(_messageBuffer, message, numberOfBytesRead);

                if (message.Length < 4) continue;
                var packetLength = BitConverter.ToInt32(message, 0);

                if (message.Length < packetLength + 4) continue;
                var resultMessage = GetMessageFromBuffer(message, packetLength);

                dynamic readMessage = JsonConvert.DeserializeObject(resultMessage);

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
    }
}