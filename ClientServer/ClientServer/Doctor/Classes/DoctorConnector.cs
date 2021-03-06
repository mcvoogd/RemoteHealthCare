﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using Doctor.Forms;
using Newtonsoft.Json;

namespace Doctor.Classes
{
    public delegate void UpdateMessages(Message message);

    public class DoctorConnector
    {
        public List<Message> MessageList { get; set; }
        public Patient CurrentPatient;
        public int CurrentPatientHistoryCount = 0;
        public List<Measurement> CurrentPatientMeasurements = new List<Measurement>();
        public readonly List<Patient> PatientesList = new List<Patient>();
        private int _loginAccepted;
        private byte[] _messageBuffer = new byte[0];
        private SslStream _sslStream;
        private TcpClient _tcpClient;
        public bool RecievedMeasurements = false;
        public bool UpdateRequired = true;
        public readonly List<Patient> CurrentPatients = new List<Patient>();
        public UpdateMessages UpdateMessages;
        public bool ReceivedHistoryMeasurements;

        public DoctorConnector()
        {
            _sslStream = null;
            CurrentPatient = null;
            MessageList = new List<Message>();
        }

        public int ConnectionId { get; set; }

        public void Receiver()
        {
            var message = new byte[1024];
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
                        if (readMessage == null)
                        {
                        }
                        else
                        {
                            string id = readMessage.id;
                            dynamic data = readMessage.data;
                            Console.WriteLine($"DOCTOR Received:\n{readMessage}");
                            switch (id)
                            {
                                case "get/patients":
                                    var patientsList = data.patients;
                                    for (var i = 0; i < patientsList.Count; i++)
                                    {
                                        int clientid = patientsList[i].ClientId;
                                        string name = patientsList[i].Name;
                                        bool isOnline = patientsList[i].IsOnline;
                                        PatientesList.Add(new Patient(clientid, isOnline, name));
                                    }
                                    CurrentPatients.Clear();
                                    CurrentPatients.AddRange(PatientesList);
                                    UpdateRequired = true;
                                    break;
                                case "get/patient/data" :
                                    Measurement m = data.LatestMeasurements.ToObject<Measurement>();
                                    CurrentPatientMeasurements.Add(m);
                                    RecievedMeasurements = true;
                                    break;
                                case "login/request":
                                    if (data.ack == false)
                                    {
                                        _loginAccepted = -1;
                                        return;
                                    }
                                    _loginAccepted = 1;

                                    break;
                                case "message/send":
                                    MessageList.Add(ParseMessage(data));
                                    UpdateMessages(ParseMessage(data));
                                    SendMessage(new
                                    {
                                        id = "message/received",
                                        data = new
                                        {
                                            received = true
                                        }
                                    });
                                    break;
                                case "get/patient/history":
                                    CurrentPatientHistoryCount = data.history;
                                    break;
                                case "get/patient/history/measurements":
                                    CurrentPatientMeasurements.Clear();
                                    for (var i = 0; i < data.measurements.Count; i++)
                                    {
                                        CurrentPatientMeasurements.Add(data.measurements[i].ToObject<Measurement>());
                                    }
                                    ReceivedHistoryMeasurements = true;
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
                Console.WriteLine("client is gone!");
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

        public List<Patient> GetAllPatients()
        {
            if (!UpdateRequired || PatientesList == null) return null;
            List<Patient> temp = new List<Patient>();
            foreach (var patient in PatientesList)
            {
                temp.Add(new Patient(patient.ClientId,patient.IsOnline,patient.Name));
            }
            UpdateRequired = false;
            return temp;
        }

        public bool Connect(string serverIp, string username, string password)
        {
            try
            {
                _tcpClient = new TcpClient(serverIp, 6969);
                _sslStream = new SslStream(_tcpClient.GetStream(), false, (a, b, c, d) => true, null);
                _sslStream.AuthenticateAsClient(_tcpClient.Client.AddressFamily.ToString());

                Login(username, password);

                var receiveThread = new Thread(Receiver);
                receiveThread.Start();

                while (_loginAccepted == 0)
                {
                    Console.WriteLine("In loop...waiting.");
                }

                switch (_loginAccepted)
                {
                    case 1:
                        _loginAccepted = 0;

                        SendMessage(new
                        {
                            id = "get/patients",
                            data = new
                            {
                                patientList = new List<Patient>() {new Patient(0, false, "0")}
                            }
                        });
                        Console.WriteLine("Send Message...");
                        return true;
                    case -1:
                        _loginAccepted = 0;
                        return false;
                }
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                return false;
            }
            
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
                    isDoctor = true,
                    isClient = false
                }
            });
        }

        public void SetCurrentPatient(Patient patient)
        {
            CurrentPatient = patient;
            CurrentPatientHistoryCount = 0;
        }

        public Message ParseMessage(dynamic data)
        {
            var toSend = new Message((int)data.targetid, (int)data.originid, DateTime.Now, (string)data.name,(string)data.message);
            return toSend;
        }

        public static int GetUniqueId(string username, string password)
        {
            if ((username == null) && (password == null)) return 0;
            var nameV = GetStringInNumbers(username);
            var passwordV = GetStringInNumbers(password);

            return (nameV*397) ^ passwordV;
        }

        public static int GetStringInNumbers(string text)
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

        public List<Measurement> GetAllMeasurements()
        {
            return CurrentPatientMeasurements;
        }

        public Measurement GetMostRecentMeasurement()
        {
            return CurrentPatientMeasurements.Count > 0 ? CurrentPatientMeasurements[CurrentPatientMeasurements.Count - 1] : null;
        }
    }

    public struct HistoryItem
    {
        public SimpleTime StartTime { get; set; }
        public SimpleTime EndTime { get; set; }

        public HistoryItem(SimpleTime startTime, SimpleTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

    }
}