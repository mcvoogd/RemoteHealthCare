using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

        private BigDatabase _database;
        private readonly SslStream _sslStream;
        private readonly TcpClient _tcpClient;
        private byte[] _messageBuffer;
        public Client Client;
        private bool IsDoctor;

        private string _certPath;

        public ClientHandler(TcpClient tcpClient, BigDatabase databaseValue)
        {
            _tcpClient = tcpClient;
            _sslStream = new SslStream(_tcpClient.GetStream());
            _database = databaseValue;

            _certPath = $@"{Directory.GetCurrentDirectory()}\RemoteHealthCareSelfGenerated.pfx";
            SetCertPath();
            _serverCertificate = new X509Certificate2(_certPath, "RemoteHealthCare");

            _sslStream.AuthenticateAsServer(_serverCertificate, false, SslProtocols.Tls, false);

            DisplaySecurityLevel(_sslStream);
            DisplaySecurityServices(_sslStream);
            DisplayCertificateInformation(_sslStream);
            DisplayStreamProperties(_sslStream);

            _messageBuffer = new byte[0];
        }

        [Conditional("DEBUG")]
        private void SetCertPath()
        {
            _certPath = @"..\..\..\RemoteHealthCareSelfGenerated.pfx";
        }

        //RECEIVER
        public void HandleClient()
        {

            Console.WriteLine("Handling client");
            var message = new byte[1024];
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
                            if (!ForwardMessage(readMessage)) Console.WriteLine("Forwarding failed... target not found!");
                            SendAck("message/received");
                            break;

                        case "client/new":
                            Console.WriteLine($"Adding new client: {data.name}");
                            var client = new Client((string)data.name, (string)data.password, null, 0, new TinyDataBase(), (bool)data.isDoctor, (int)data.doctorId, false);
                            _database.AddClient(client);
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
                                ClientHandlerSeppuku();
                                return; // Make sure to end the thread if the login is incorrect
                            }
                            break;
                        case "client/disconnect":
                            Client.IsOnline = false;
                            Disconnect();
                            break;

                        case "change/resistance":
                            if (IsDoctor)
                                HandleResistance(data);
                            break;
                        case "get/patients":
                            if (IsDoctor)
                            { 
                                HandleGetPatients(readMessage);
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
                        case "get/patient/history":
                            if (IsDoctor)
                            {
                                HandlePatientHistory(data);
                            }
                            break;
                        case "get/patient/history/measurements":
                            if (IsDoctor)
                            {
                                HandlePatientPersonalHistory(data);
                            }
                            break;
                        case "broadcast":
                            BroadCast(data);
                            break;
                        case "new/history/item":
                            if (IsDoctor)
                            {
                                HandleNewHistoryItem(data);
                            }
                            break;
                        default:
                            Console.WriteLine("Id: " + id);
                            break;
                    }
                }
                catch (Exception e)
                {
                //   Console.WriteLine(e.StackTrace);
                    if (_tcpClient.Connected) continue;
                    try
                    {
                        //TODO Is this .isOnline call safe?//no..?
                        Client.IsOnline = false;
                    }
                    catch (Exception)
                    {
                        // no more stacktrace printing on IsOnline
                    }
                    ClientHandlerSeppuku();
                    Console.WriteLine("Client disconnected.");
                }
            ClientHandlerSeppuku();
        }

        private void HandleNewHistoryItem(dynamic data)
        {
            int id = data.id;
            var client = _database.Clients.Find(p => p.UniqueId == id);
            HistoryItem temp = new HistoryItem((SimpleTime)data.historyItem.StartTime.ToObject<SimpleTime>(), 
                (SimpleTime)data.historyItem.EndTime.ToObject<SimpleTime>());
            client.TinyDataBaseBase.MeasurementSystem.History.Add(temp);
        }

        // Have the clienthandler kill itself
        private void ClientHandlerSeppuku()
        {
            //seppuku? xD
            Disconnect();
            Client = null;
            _database = null;
            TcpServer.ClientHandlers.Remove(this); // Client handler seppuku
        }

        private void HandlePatientPersonalHistory(dynamic data)
        {
            int id = data.patient;
            var client = _database.Clients.Find(p => p.UniqueId == id);

            HistoryItem temp2 = client.TinyDataBaseBase.MeasurementSystem.History[(int)data.historyItem];
            var temp = client.TinyDataBaseBase.MeasurementSystem.GetMeasurementsBetweenTimes((SimpleTime)temp2.StartTime, (SimpleTime)temp2.EndTime);
            SendMessage(new
            {
                id = "get/patient/history/measurements",
                data = new
                {
                    measurements = temp
                }
            });
        }

        public void BroadCast(dynamic data)
        {
            Console.WriteLine("Send broadcast message : " + data.Message);
            foreach (var client in TcpServer.ClientHandlers)
            {
                client.SendMessage(new
                {
                    id = "message/send",
                    data = new
                    {
                        message = data.message,
                        originid = data.originid,
                        name = data.name,
                        targetid = client.Client.UniqueId
                    }
                });
            }
        }

        private void HandlePatientHistory(dynamic data)
        {
            int id = data.patient;
            var client = _database.Clients.Find(p => p.UniqueId == id);
            if(client == null) return;
            List<HistoryItem> temp = client.TinyDataBaseBase.MeasurementSystem.History;
            if(temp.Count <= 0) return;
          SendMessage(new
          {
              id = "get/patient/history",
              data = new
              {
                  history = temp
              }
          });
        }

        // forward a received message to another client
        private bool ForwardMessage(dynamic message)
        {
            if (!Client.IsDoctor)
                message.data.targetid = Client.DoctorId;
            Console.WriteLine($"Forwarding to: {message.data.targetid}");
            foreach (var clientHandler in TcpServer.ClientHandlers)
            {
                if (clientHandler.Client.UniqueId != (int) message.data.targetid) continue;
                Console.WriteLine("Forwarding...");
                clientHandler.SendMessage(message);
                Console.WriteLine("Done!");
                return true;
            }
            return false;
        }

        //return all data for individual patient.
        private void HandlePatientData(dynamic data)
        {
            int id = data.clientId;
            var client = TcpServer.GetClientHandlerByClientID(id);

            // There was a small bug: The measurement array would go out of range if the array was empty.
            // I added a simple check to work around it.
            if (client.Client.TinyDataBaseBase.MeasurementSystem.Measurements.Count <= 0)
            {
                Console.WriteLine("Doctor requested patient data, but the list is empty...");
                return;
            }

            var measurement = client.Client.TinyDataBaseBase.MeasurementSystem.Measurements
                [client.Client.TinyDataBaseBase.MeasurementSystem.Measurements.Count - 1];
            SendMessage(new
            {
                id = "get/patient/data",
                data = new
                {
                    LatestMeasurements = measurement
                }
            });
        }

        //return all patient names + id.
        private void HandleGetPatients(dynamic data)
        {
            var patientsList = new List<Patient>();
            List<Patient> fromDoctor = new List<Patient>();
            for (int t = 0; t < data.data.patientList.Count; t++)
            {
                fromDoctor.Add(data.data.patientList[t].ToObject<Patient>());
            }
            if (_database.Clients.Count <= 0 || _database.Clients == null) return;
            foreach (Client client in _database.Clients)
            {
                if (client.IsDoctor) continue;
                patientsList.Add(new Patient(client.UniqueId, client.IsOnline, client.Name));
            }
            if (patientsList.Count == 0) return;
            if(CheckSimilar(fromDoctor, patientsList))return;
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
            ForwardMessage(data);
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
            try
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
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
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
                Console.WriteLine("parsing time went wrong!");
                tempTime = new SimpleTime(3, 10);
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
                    tempTime.Minutes,tempTime.Seconds,
                    (int) data.reachedpower);

                return tempMeasurement;
            }
            catch (Exception exception)
            {
               // Console.WriteLine($"Exception: {exception}\nStack trace: {exception.StackTrace}");
                return null;
            }
        }

        public Message ParseMessage(dynamic data)
        {
            Console.WriteLine("Parse message: " + data);
            var toSend = new Message((string) data.clientid, (string) data.clientid, DateTime.Now,
                (string)data.name,(string) data.data.message);
            return toSend;
        }

        public bool CheckSimilar(List<Patient> first, List<Patient> second)
        {
            if (first.Count != second.Count) return false;
            int index = 0;
            bool answer = false;
            foreach (var patient in first)
            {//ehh okay?
                answer = patient.IsOnline == second[index].IsOnline;
                index++;
                if (!answer) return false;
            }
            return answer;
        }

        public bool HandleLogin(dynamic data)
        {
            string username = data.username;
            string password = data.password;
            int clientid = data.clientid;
            bool isDoctorData = data.isDoctor;

            
            Console.WriteLine($"Name {username} | password {string.Concat(Enumerable.Repeat("*", password.Length))} | clientid {clientid}");
        
            if (_database.GetClientById(clientid) == null)
            {
                return false; // Return false if client does not exist
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