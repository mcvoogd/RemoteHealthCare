using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;
using Server.BigDB;
using Server.TinyDB;

namespace Server.Server
{
    public class ClientHandler
    {
        private static X509Certificate2 _serverCertificate;

        private readonly BigDatabase _database;
        private readonly SslStream _sslStream;
        private readonly TcpClient _tcpClient;
        private byte[] _messageBuffer;
        public Client Client;
        private bool IsDoctor;

        public ClientHandler(TcpClient tcpClient, BigDatabase databaseValue)
        {
            _tcpClient = tcpClient;
            _sslStream = new SslStream(_tcpClient.GetStream());
            _database = databaseValue;
            _serverCertificate = new X509Certificate2(@"..\..\..\RemoteHealthCareSelfGenerated.pfx", "RemoteHealthCare");

            _sslStream.AuthenticateAsServer(_serverCertificate, false, SslProtocols.Tls, false);

            DisplaySecurityLevel(_sslStream);
            DisplaySecurityServices(_sslStream);
            DisplayCertificateInformation(_sslStream);
            DisplayStreamProperties(_sslStream);

            _messageBuffer = new byte[0];
        }

        //RECEIVER
        public void HandleClient()
        {
            Console.WriteLine("Handling client");
            var message = new byte[128];
            var sizeBuffer = new byte[0];
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

                    var id = readMessage.id;
                    dynamic data = readMessage.data;

                    switch ((string) id)
                    {
                        case "message/send":
                            Client.TinyDataBaseBase.ChatSystem.AddMessage(ParseMessage(readMessage));
                            Console.WriteLine("MSG : " + data.message);
                            if (!forwardMessage(readMessage)) Console.WriteLine("Forwarding failed... target not found!");
                            SendAck("message/received");
                            break;
                        case "client/new":
                            //null == tunnelID. <VR>
                            //0 for self generate ID.
                            //Latest argument true is a indication for the client being online.
                            Client = new Client(data.username, data.password, null, 0, data.isDoctor, new TinyDataBase(), true);
                            Console.WriteLine(
                                $"Msg added. <{Client.TinyDataBaseBase.ChatSystem.GetAllMessages().Count}>");
                            _database.AddClient(Client);
                            SendAck("client/new");
                            break;
                        case "measurement/add":
                            Client.TinyDataBaseBase.MeasurementSystem.AddMeasurement(ParseMeasurement(data));
                            Console.WriteLine(
                                $"Msrment added. <{Client.TinyDataBaseBase.MeasurementSystem.GetAllMeasurements().Count}>");
                            SendAck("measurement/add");
                            break;
                        case "login/request":
                            if (HandleLogin(data))
                            {
                                SendAck("login/request");
                                Console.WriteLine(Client.UniqueId + " <UNIQUE ID>");
                            }
                            else
                            {
                                SendNotAck("login/request");
                            }
                            break;
                        case "client/disconnect":
                            Client.IsOnline = false;
                            _sslStream.Close();
                            _tcpClient.Close();
                            break;

                        case "change/resistance":
                            if (IsDoctor)
                                HandleResistance(data);
                            break;
                        case "get/patients":
                            if (IsDoctor)
                            { 
                                HandleGetPatients(data);
                            }
                            else
                            {
                                Console.WriteLine("IS NOT DOCTOR");
                            }
                            break;
                        case "get/patient/data":
                            if (IsDoctor)
                                HandlePatientData(data);
                            break;
                        default:
                            Console.WriteLine("Id: " + id);
                            break;
                    }
                }
                catch (Exception)
                {
                    if (_tcpClient.Connected) continue;
                    //TODO Is this .isOnline call safe?
                    Client.IsOnline = false;
                    Console.WriteLine("Client disconnected.");
                    //    Console.WriteLine(e.StackTrace);
                }
        }

        // forward a received message to another client
        private bool forwardMessage(dynamic message)
        {
            foreach (var clientHandler in TcpServer.ClientHandlers)
            {
                if (clientHandler.Client.UniqueId != (int) message.targetid) continue;
                clientHandler.SendMessage(message);
                return true;
            }
            return false;
        }

        //return all data for individual patient.
        private void HandlePatientData(dynamic data)
        {
            int id = data.clientId;
            ClientHandler client = TcpServer.GetClientHandlerByClientID(id);
            var measurement = client.Client.TinyDataBaseBase.MeasurementSystem._measurements
                [client.Client.TinyDataBaseBase.MeasurementSystem._measurements.Count - 1];
            SendMessage(new
            {
                id = "get/patient/data",
                data = new
                {
                    measurementsList = measurement
                }
            });
        }

        //return all patient names + id.
        private void HandleGetPatients(dynamic data)
        {
            List<Patient> patientsList = new List<Patient>();
            int index = 0;
            if(_database.Clients.Count > 0 && _database.Clients != null)
            foreach (var databaseClient in _database.Clients)
            {
                if(databaseClient.IsDoctor) continue;
                if(!databaseClient.IsOnline) continue;
                var temp = new Patient(databaseClient.UniqueId, databaseClient.Name);
                patientsList.Add(temp);
                index++;
            }

            SendMessage(new
            {
                id = "get/patients",
                data = new
                {
                    patients = patientsList.ToArray()
                }
            });
        }

        //from doctor to client.
        public void HandleResistance(dynamic data)
        {
            //TODO fix this with the correct client (forward message)
            forwardMessage(data);
            //ClientHandler tosend = TcpServer.GetClientHandlerByClientID(data.clientId);
            //tosend.SendMessage(new
            //{
            //    id = "change/resistance",
            //    data = new
            //    {
            //        Resistance = data.resistance
            //    }
            //});
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
            if (!_tcpClient.Connected) return;
            SendMessage(new
            {
                id = "client/disconnect",
                data = new
                {
                    Disconnect = true
                }
            });
            _tcpClient.GetStream().Close();
            _tcpClient.Close();
        }

        public void SendMessage(dynamic message)
        {
            if ((_sslStream == null) || !_tcpClient.Connected) return;
            message = JsonConvert.SerializeObject(message);
            var buffer = Encoding.Default.GetBytes(message);
            var bufferPrepend = BitConverter.GetBytes(buffer.Length);

            _sslStream.Write(bufferPrepend, 0, bufferPrepend.Length);
            _sslStream.Write(buffer, 0, buffer.Length);
        }

        public Measurement ParseMeasurement(dynamic data)
        {
            var tempString = (string) data.time;
            Console.WriteLine("Received Measurement: " + data);

            Console.WriteLine("Time: " + tempString);
            var temp = tempString.Split(':');

            SimpleTime tempTime;
            try
            {
                tempTime = new SimpleTime(int.Parse(temp[0]), int.Parse(temp[1]));
            }
            catch (Exception)
            {
                Console.WriteLine("parsing time fucks up!");
                tempTime = new SimpleTime(0, 0);
            }

            try
            {
                var tempMeasurement = new Measurement(
                    (int) data.pulse,
                    (int) data.rotations,
                    (int) data.speed,
                    (int) data.power,
                    (double) data.distance,
                    (double) data.burned,
                    tempTime,
                    (int) data.reachedpower);

                return tempMeasurement;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception: {exception}\nStack trace: {exception.StackTrace}");
                return null;
            }
        }

        public Message ParseMessage(dynamic data)
        {
            Console.WriteLine("Parse message: " + data);
            var toSend = new Message((string) data.clientid, (string) data.clientid, DateTime.Now,
                (string) data.data.message);
            return toSend;
        }

        public bool HandleLogin(dynamic data)
        {
            string username = data.username;
            string password = data.password;
            int clientid = data.clientid;
            bool isDoctorData = data.isDoctor;

            Console.WriteLine($"Name {username} | password {password} | clientid {clientid}");
            if (_database.GetClientById(clientid) == null)
            {
                Client = new Client(username, password, null, 0, isDoctorData, new TinyDataBase(), true);
                _database.AddClient(Client);
                if (isDoctorData)
                {
                    this.IsDoctor = true;
                }
                Console.WriteLine("Did not exist");
                return true;
            }
            //null == tunnelID. <VR>
            _database.GetClientById(clientid, out Client);
            if (isDoctorData)
            {
                IsDoctor = true;
            }
            Client.IsOnline = true;
            return true;
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

        #region Ssl security displays

        private static void DisplaySecurityLevel(SslStream stream)
        {
            Console.WriteLine($"Cipher: {stream.CipherAlgorithm} strength {stream.CipherStrength}");
            Console.WriteLine($"Hash: {stream.HashAlgorithm} strength {stream.HashStrength}");
            Console.WriteLine($"Key exchange: {stream.KeyExchangeAlgorithm} strength {stream.KeyExchangeStrength}");
            Console.WriteLine($"Protocol: {stream.SslProtocol}");
        }

        private static void DisplaySecurityServices(SslStream stream)
        {
            Console.WriteLine($"Is authenticated: {stream.IsAuthenticated} as server? {stream.IsServer}");
            Console.WriteLine($"IsSigned: {stream.IsSigned}");
            Console.WriteLine($"Is Encrypted: {stream.IsEncrypted}");
        }

        private static void DisplayStreamProperties(SslStream stream)
        {
            Console.WriteLine($"Can read: {stream.CanRead}, write {stream.CanWrite}");
            Console.WriteLine($"Can timeout: {stream.CanTimeout}");
        }

        private static void DisplayCertificateInformation(SslStream stream)
        {
            Console.WriteLine($"Certificate revocation list checked: {stream.CheckCertRevocationStatus}");

            var localCertificate = stream.LocalCertificate;
            if (stream.LocalCertificate != null)
                Console.WriteLine(
                    $"Local cert was issued to {localCertificate.Subject} and is valid from {localCertificate.GetEffectiveDateString()} " +
                    $"until {localCertificate.GetExpirationDateString()}.");
            else
                Console.WriteLine("Local certificate is null.");
            // Display the properties of the client's certificate.
            var remoteCertificate = stream.RemoteCertificate;
            if (stream.RemoteCertificate != null)
                Console.WriteLine(
                    $"Remote cert was issued to {remoteCertificate.Subject} and is valid from " +
                    $"{remoteCertificate.GetEffectiveDateString()} until {remoteCertificate.GetExpirationDateString()}.");
            else
                Console.WriteLine("Remote certificate is null.");
        }

        #endregion
    }
}