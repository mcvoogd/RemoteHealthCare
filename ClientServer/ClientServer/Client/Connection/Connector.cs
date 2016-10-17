using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using Client.Forms;
using Client.Simulator;
using Newtonsoft.Json;

namespace Client.Connection
{
    // public delegate void Message(string message);

    internal class Connector
    {
        private readonly List<Message> _messageList;
        private byte[] _messageBuffer = new byte[0];
        private SslStream _sslStream;
        private TcpClient _tcpClient;
        private int loginAccepted;
        public RemoteHealthcare RemoteHealthcare;

        public Connector()
        {
            _sslStream = null;
            _messageList = new List<Message>();
        }

        //    public Message Message { get; set; }

//        private NetworkStream _stream;
        public int ConnectionId { get; set; }

        public void Receiver()
        {
            var message = new byte[128];
            var sizeBuffer = new byte[4];

            try
            {
                while (_tcpClient.Connected)
                    try
                    {
                        var numberOfBytesRead = _sslStream.Read(message, 0, message.Length);
                        _messageBuffer = ConCat(_messageBuffer, message, numberOfBytesRead);

                        if (_messageBuffer.Length <= 4) continue;
                        var packetLength = BitConverter.ToInt32(_messageBuffer, 0);

                        if (_messageBuffer.Length < packetLength + 4) continue;

                        var resultMessage = GetMessageFromBuffer(_messageBuffer, packetLength);
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
                                    if (data.ack == false)
                                    {
                                        loginAccepted = -1;
                                        return;
                                    }
                                    loginAccepted = 1;
                                    RemoteHealthcare.ConnectionId = ConnectionId;
                                    break;
                                case "message/send":
                                    Console.WriteLine("CLIENT: Received message: " + data.message);
                                    _messageList.Add(ParseMessage(data));
                                    RemoteHealthcare.AddMessage(ParseMessage(data));
                                    SendMessage(new
                                    {
                                        id = "message/received",
                                        data = new
                                        {
                                            received = true
                                        }
                                    });
                                    break;
                                case "change/resistance/sendList":
                                    RemoteHealthcare.SendCommandToBike(data);
                                    break;
                                case "bike/break":
                                    EmergencyBreak();
                                    break;
                                case "client/disconnect":
                                    _sslStream.Close();
                                    _tcpClient.Close();
                                    break;
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.StackTrace);
                        if (!_tcpClient.Connected)
                            Console.WriteLine("Client disconnected.");
                    }
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null)
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                Console.WriteLine("Authentication failed - closing the connection.");
                _tcpClient.Close();
            }
        }

        private void EmergencyBreak()
        {
            RemoteHealthcare.Form1.Tunnel.ResetScene();
        }

        public bool Connect(string serverIp, string username, string password, RemoteHealthcare remoteHealthcare)
        {
            try
            {
                RemoteHealthcare = remoteHealthcare;

                _tcpClient = new TcpClient(serverIp, 6969);
                _sslStream = new SslStream(_tcpClient.GetStream(), false, (a, b, c, d) => true, null);
                _sslStream.AuthenticateAsClient(_tcpClient.Client.AddressFamily.ToString());

                Login(username, password);

                var receiveThread = new Thread(Receiver);
                receiveThread.Start();

                while (loginAccepted == 0)
                {
                }

                switch (loginAccepted)
                {
                    case 1:
                        loginAccepted = 0;
                        return true;
                    case -1:
                        loginAccepted = 0;
                        return false;
                }
                return false;
            }
            catch (Exception exception)
            {
                //                Console.WriteLine(exception.StackTrace);
                return false;
            }
            
        }

        public void SendStatistics(Measurement measurement)
        {
            SendMessage(new
            {
                id = "measurement/add",
                clientid = ConnectionId,
                data = new
                {
                    pulse = measurement.Pulse,
                    rotations = measurement.Rotations,
                    speed = measurement.Speed,
                    distance = measurement.Distance,
                    power = measurement.Power,
                    burned = measurement.Burned,
                    time = measurement.Time.ToString(),
                    reachedpower = measurement.ReachedPower
                }
            });
        }

        private void Login(string username, string password)
        {
            if (_sslStream == null) return;

            ConnectionId = GetUniqueId(username, password);
            SendMessage(new
            {
                id = "login/request",
                data = new
                {
                    username,
                    clientid = ConnectionId,
                    password,
                    isDoctor = false
                }
            });
        }

        public Message ParseMessage(dynamic data)
        {
            var toSend = new Message((int)data.targetid, (int)data.originid, DateTime.Now,(string)data.name ,(string)data.message);
            return toSend;
        }

        public int GetUniqueId(string username, string password)
        {
            if ((username == null) && (password == null)) return 0;
            var nameV = GetStringInNumbers(username);
            var passwordV = GetStringInNumbers(password);

            return (nameV*397) ^ passwordV;
        }

        public int GetStringInNumbers(string text)
        {
            var nameArray = text.ToCharArray();
            return nameArray.Sum(c => (int) c%32);
        }

        public void SendMessage(dynamic message)
        {
            if ((_sslStream == null) || !_tcpClient.Connected) return;

            Console.WriteLine("sending message");
            message = JsonConvert.SerializeObject(message);
            var buffer = Encoding.Default.GetBytes(message);
            var bufferPrepend = BitConverter.GetBytes(buffer.Length);

            _sslStream.Write(bufferPrepend, 0, bufferPrepend.Length);
            _sslStream.Write(buffer, 0, buffer.Length);
            _sslStream.Flush();
            Console.WriteLine("Message send");
        }

        // Gets the first message from the buffer that isn't idicating the size
        private string GetMessageFromBuffer(byte[] array, int count)
        {
            var newArray = new byte[array.Length - (count + 4)];

            var message = new StringBuilder();
            message.AppendFormat("{0}", Encoding.ASCII.GetString(array, 4, count));

            for (var i = 0; i < newArray.Length; i++)
                newArray[i] = array[i + count + 4];
            _messageBuffer = newArray;

            return message.ToString();
        }

        // Combine two byte arrays into one.
        // count amount of bytes to copy from the second arrays
        private static byte[] ConCat(byte[] arrayOne, byte[] arrayTwo, int count)
        {
            var newArray = new byte[arrayOne.Length + count];
            Buffer.BlockCopy(arrayOne, 0, newArray, 0, arrayOne.Length);
            Buffer.BlockCopy(arrayTwo, 0, newArray, arrayOne.Length, count);
            return newArray;
        }
    }
}