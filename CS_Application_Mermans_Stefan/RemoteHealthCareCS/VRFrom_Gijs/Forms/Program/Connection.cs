using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using VRFrom_Gijs.VrObjects;
using VRFrom_Gijs.Forms;
using Panel = System.Windows.Forms.Panel;

namespace VRFrom_Gijs.Program
{
    public delegate void FillConnectionList();

    public delegate void Callbacks();

    public class Connection
    {
        public string VrServerIp { get; set; }
        public int VrServerPort { get; set; }
        public string TunnelId { get; set; }
        public string UserName { get; set; }
        private TcpClient _client;
        public NetworkStream NetworkStream { get; set; }
        public JsonRawData JsonRawData { get; set; }
        public Form1 Form { get; set; }
        public FillConnectionList FillConnectionList;
        public static Dictionary<string, string> VRobjecten = new Dictionary<string, string>();
        public List<Node> Nodes = new List<Node>();
        public string TerrainId { get ; private set; } // TODO store somewhere else
        public string GroundPlanId { get; set; } //TODO SAME AS ABOVE.
        public string RouteId { get; set; }
        public string cameraID { get; set; }
        public string headID { get; set; }
        public string PanelId { get; set; }

        public Connection(string ip, int port, Form1 form)
        {
            VrServerIp = ip;
            VrServerPort = port;
            Form = form;
            FillConnectionList = form.FillConnectionList;
        }

        public void StartConnection()
        {
            try
            {
                Console.WriteLine("Connecting...");
                _client = new TcpClient(VrServerIp, VrServerPort);
                Console.WriteLine("Connected: " + _client.Connected);
                NetworkStream = _client.GetStream();

                string request = "{\"id\" : \"session/list\"}";

                SendMessage(request);
                byte[] receiveBuffer = new byte[128];
                byte[] bufferBytes = new byte[0];

                do
                {
                    var numberOfBytesRead = NetworkStream.Read(receiveBuffer, 0, receiveBuffer.Length);
                    bufferBytes = ConCat(bufferBytes, receiveBuffer, numberOfBytesRead);

                    if (bufferBytes.Length < 4) continue;

                    var packetLength = BitConverter.ToInt32(bufferBytes, 0);

                    if (bufferBytes.Length < packetLength + 4) continue;

                    var result = GetMessageFromBuffer(bufferBytes, packetLength);
                   
                    dynamic red = JsonConvert.DeserializeObject(result);
                    switch ((string) red.id)
                    {
                        case "session/list":
                            var res = JsonConvert.DeserializeObject<JsonRawData>(result);
                            JsonRawData = res;
                            Form.Invoke(FillConnectionList);
                            break;
                        case "tunnel/create":
                            Console.WriteLine(red);
                            this.TunnelId = red.data.id;
                            break;
                        case "tunnel/send":
                            switch ((string) red.data.data.id)
                            {
                                case "scene/node/add":
                                    Console.WriteLine(red.data.data.data);
                                    string tempNaam = red.data.data.data.name;
                                    string tempUuid = red.data.data.data.uuid;
                                    Console.WriteLine(tempNaam);

                                    if (tempNaam == "panel")
                                        PanelId = red.data.data.data.uuid;
                                   

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
                                        if (GetNodeInList(tempNaam) != null)
                                            GetNodeInList(tempNaam).Uuid = tempUuid;
                                    }
                                    TunnelCommandForm.Blocker.Set();
                                    break;
                                case "scene/get":
                                    GroundPlanId =
                                        red.data.data.data.children[red.data.data.data.children.Count - 1].uuid;
                                    cameraID = red.data.data.data.children[1].uuid;
                                    headID = red.data.data.data.children[4].uuid;
                                    TunnelCommandForm.Blocker.Set();
                                    break;
                                case "scene/node/delete":
                                    Console.WriteLine("Deleted.");
                                    TunnelCommandForm.Blocker.Set();
                                    break;
                                case "route/add":
                                    RouteId = red.data.data.data.uuid;
                                    TunnelCommandForm.Blocker.Set();
                                    break;
                            }
                            TunnelCommandForm.Blocker.Set();
                            break;
                    }
                    bufferBytes = SubArray(bufferBytes, packetLength + 4, bufferBytes.Length - (packetLength + 4));

                } while (_client.Connected);
            }
            catch (Exception)
            {
                Console.WriteLine("Error while connecting");
            }
        }

        private static string GetMessageFromBuffer(byte[] array, int count)
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
            return _client != null ? _client.Connected : false;
        }

        public Node GetNodeInList(string naam)
        {
            foreach (Node node in Nodes)
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

        public void SendMessage(string request)
        {
            byte[] buffer = Encoding.Default.GetBytes(request);
            byte[] bufferPrepend = BitConverter.GetBytes(buffer.Length);

            NetworkStream.Write(bufferPrepend, 0, bufferPrepend.Length);
            NetworkStream.Write(buffer, 0, buffer.Length);
        }
    }
}
