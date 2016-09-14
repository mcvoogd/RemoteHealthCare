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
        public string naam { get; set; }
        public int Uuid { get; set; }

        public Node(String naam, string TunnelID)
        {
            //AddNode(TunnelID, naam, )
        }

        public dynamic AddNode(string TunnelID, string Name, string FileName, int x, int y, int z, double ScaleValue = 0.025, double xR = 0, double yR = 0, double zR = 0)
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
                            position = new[] { x, y, x },
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
    }
}
