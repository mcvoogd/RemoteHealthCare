using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRConnectorForm.Program;

namespace VRConnectorForm.VRobjects
{
    class Panel
    {
        public string Uuid;
        public string ToSend;

        public Panel(string Name, int scaleValue, int x, int y, int z, int xR, int yR, int zR, int size1, int size2 ,int width, int height, int bckground1, int bckground2, int bckground3, int bckground4, string tunnelID)
        {
            ToSend = RequestCreater.TunnelSend(new
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
                            scale = scaleValue,
                            rotation = new[] { xR, yR, zR }
                        },
                        panel = new {
                            size = new[] {size1, size2},
                            resolution = new[] {width, height},
                            background = new[] {bckground1, bckground2, bckground3, bckground4}
                        
                    }
                    }

                }
            }, tunnelID);
        }

    }
}
