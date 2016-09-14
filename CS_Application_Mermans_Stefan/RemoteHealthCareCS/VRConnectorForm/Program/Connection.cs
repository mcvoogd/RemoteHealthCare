﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Text;
using Newtonsoft.Json;
using VRConnectorForm.Forms;
using VRConnectorForm.VRobjects;

namespace VRConnectorForm.Program
{
    public delegate void FillConnectionList();


    public class Connection
    {
        public string VRServerIP { get; set; }
        public int VRServerPort { get; set; }
        public string TunnelID { get; set; }
        public string UserName { get; set; }
        private TcpClient Client;
        public NetworkStream NetworkStream { get; set; }
        public JsonRawData JsonRawData { get; set; }
        public Form1 Form { get; set; }
        public FillConnectionList FillConnectionList;
        public static Dictionary<string, string> VRobjecten = new Dictionary<string, string>();
        public List<Node> nodes = new List<Node>();
        public string TerrainId { get ; private set; } // TODO store somewhere else

        public Connection(string IP, int port, Form1 form)
        {
            this.VRServerIP = IP;
            this.VRServerPort = port;
            Form = form;
            FillConnectionList = form.FillConnectionList;
        }


        public void StartConnection()
        {
            try
            {
                Console.WriteLine("Connecting...");
                Client = new TcpClient(VRServerIP, VRServerPort);
                Console.WriteLine("Connected: " + Client.Connected);
                NetworkStream = Client.GetStream();

                string request = "{\"id\" : \"session/list\"}";

                sendMessage(request);
                byte[] receiveBuffer = new byte[128];
                byte[] bufferBytes = new byte[0];

                do
                {
                    var numberOfBytesRead = NetworkStream.Read(receiveBuffer, 0, receiveBuffer.Length);
                    bufferBytes = ConCat(bufferBytes, receiveBuffer, numberOfBytesRead);
                    if (bufferBytes.Length >= 4)
                    {
                        var packetLength = BitConverter.ToInt32(bufferBytes, 0);

                        if (bufferBytes.Length >= packetLength + 4)
                        {
                            var result = GetMessageFromBuffer(bufferBytes, packetLength);

                            dynamic red = JsonConvert.DeserializeObject(result);
                            
                            switch ((String) red.id)
                            {
                                case "session/list":
                                    var res = JsonConvert.DeserializeObject<JsonRawData>(result);
                                    JsonRawData = res;
                                    Form.Invoke(FillConnectionList);
                                    break;
                                case "tunnel/create":
                                    this.TunnelID = red.data.id;
                                    break;
                                case "tunnel/send":
//                                    Console.WriteLine("------------------\n" + red + "----------------------\n");
                                    switch ((string) red.data.data.id)
                                    {
                                        case "scene/node/add":
                                            Console.WriteLine(red.data.data.data);
                                            string tempNaam = red.data.data.data.name;
                                            string tempUuid = red.data.data.data.uuid;
                                            Console.WriteLine(tempNaam);
                                            if (tempNaam == "Terrain node")
                                            {
                                                TerrainId = red.data.data.data.uuid;
                                                //Console.WriteLine("SWITCH" + tempNaam + ": " + red.data.data.data.uuid);
                                                // Sets the id of the terrain, the storage of this id should probably be moved somewhere else.
                                                // This may not even be necessary at all if the terrain node is stored in VRobjecten
                                                // TODO move
                                            } else if (!VRobjecten.ContainsKey(tempNaam))
                                            {
                                                VRobjecten.Add(tempNaam, tempUuid);
                                                if(getNodeINList(tempNaam) != null)
                                                getNodeINList(tempNaam).Uuid = tempUuid;
                                            }
                                            break;
                                        case "scene/get":
                                            Console.WriteLine(red.data.data.data);
                                            break;
                                    }
                                    break;
                            }
                          
                                
                             bufferBytes = SubArray(bufferBytes, packetLength + 4, bufferBytes.Length - (packetLength + 4));
                        }
                    }
                } while (Client.Connected);
               
            }
            catch (Exception)
            {
                Console.WriteLine("Error while connecting");
            }
        }

        private string GetMessageFromBuffer(byte[] array, int count)
        {
            var message = new StringBuilder();
            message.AppendFormat("{0}", Encoding.ASCII.GetString(array,4,count));
            return message.ToString();
        }



        // Combine two byte arrays into one.
        // count amount of bytes to copy from the second arrays
        public byte[] ConCat(byte[] arrayOne, byte[] arrayTwo, int count)
        {
            var newArray = new byte[arrayOne.Length + count];
            System.Buffer.BlockCopy(arrayOne,0,newArray,0,arrayOne.Length);
            System.Buffer.BlockCopy(arrayTwo,0,newArray,arrayOne.Length,count);
            return newArray;
        }

        public byte[] SubArray(byte[] data, int index, int length)
        {
            byte[] result = new byte[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public bool IsConnected()
        {
            return Client != null ? Client.Connected : false;
        }

        public Node getNodeINList(string naam)
        {
            foreach (Node node in nodes)
            {
                if (node.Naam.Equals(naam))
                {
                    return node;
                }
            }
            return null;
        }

        // Remove the first message from a byte array
        public byte[] NotConCat(byte[] array, int count)
        {
            var tempArray = new byte[array.Length - count];
            for (int i = 0; i < array.Length - count; i++)
            {
                tempArray[i] = array[count + i];
            }
            return tempArray;
        }

        public void sendMessage(string request)
        {
            byte[] buffer = Encoding.Default.GetBytes(request);
            byte[] bufferPrepend = BitConverter.GetBytes(buffer.Length);

            NetworkStream.Write(bufferPrepend, 0, bufferPrepend.Length);
            NetworkStream.Write(buffer, 0, buffer.Length);
        }
    }
}