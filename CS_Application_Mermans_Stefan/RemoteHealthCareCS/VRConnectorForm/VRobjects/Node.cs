using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRConnectorForm.Program;

namespace VRConnectorForm.VRobjects
{
    class Node
    {
        public string Naam { get; set; }
        public string Uuid { get; set; }
        public readonly string SendString;
        public readonly string TunnelID;

        public Node(string naam, string tunnelId, string filename, int x, int y, int z)
        {
            this.Naam = naam;
            this.TunnelID = tunnelId;
            SendString = AddNode(tunnelId, Naam, filename, x, y, z);
        }

        private dynamic AddNode(string TunnelID, string Name, string FileName, int x, int y, int z, double ScaleValue = 0.025, double xR = 0, double yR = 0, double zR = 0)
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

        public string MoveNode(int x, int y, int z,  int timeValue)
        {
            string temp;
            Connection.VRobjecten.TryGetValue(Naam, out temp);
            Uuid = temp;
            Console.WriteLine("UUID : " + Uuid);    
              
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
