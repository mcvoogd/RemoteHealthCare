using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRConnectorForm.Program;

namespace VRConnectorForm.VRobjects
{
    public class Node
    {
        public string Naam { get; set; }
        public string Uuid { get; set; } = null;
        public readonly string SendString;
        public readonly string TunnelID;

        public Node(string naam, string tunnelId, string filename, int x, int y, int z, double scale)
        {
            this.Naam = naam;
            this.TunnelID = tunnelId;
            SendString = AddModelNode(tunnelId, Naam, filename, x, y, z, scale);
        }

        public Node(string name, string tunnelId, double x, double y, double z)
        {
            Naam = name;
            TunnelID = tunnelId;
            SendString = AddTerrainNode(TunnelID, "Terrain node", x, y, z);
        }

        private dynamic AddModelNode(string TunnelID, string Name, string FileName, int x, int y, int z, double ScaleValue = 1, double xR = 0, double yR = 0, double zR = 0)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/node/add",
                data = new
                {
                    name = Name,
                    components = new
                    {
                        transform = new
                        {
                            position = new[] { x, y, z },
                            scale = ScaleValue,
                            rotation = new[] { xR, yR, zR }
                        },
                        model = new
                        {
                            file = FileName
                        }
                    }

                }
            }, TunnelID);
        }

        private dynamic AddTerrainNode(string tunnelID, string Name, double x, double y, double z, double ScaleValue = 1, double xR = 0, double yR = 0, double zR = 0)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/node/add",
                data = new
                {
                    name = Name,
                    components = new
                    {
                        transform = new
                        {
                            position = new[] { x, y, z },
                            scale = ScaleValue,
                            rotation = new[] { xR, yR, zR }
                        },
                       terrain = new
                       {
//                           smoothnormals = true
                       }
                    }

                }
            }, TunnelID);
        }

        public string MoveNode(int x, int y, int z, int timeValue)
        {
            if (Uuid == null)
            {          
                string temp;
                Connection.VRobjecten.TryGetValue(Naam, out temp);
                Uuid = temp;
            }            
            return RequestCreater.TunnelSend(
                new
                {
                    id = "scene/node/moveto",
                    data = new
                    {
                        id = Uuid,                      
                        position = new []{x,y,z},
                        rotate = "none",
                        interpolate = "linear",
                        followheight = false,
                        time = timeValue
                    }
                }, TunnelID);
        }


    }
}
