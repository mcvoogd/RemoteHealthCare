using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRFrom_Gijs.Program;

namespace VRFrom_Gijs.VrObjects
{
    class Panel
    {
        public string Uuid { get; set; }
        public string ToSend { get; set; }
        public string TunnelId { get; }
        public string name { get; set; }

        public Panel(string name, int scaleValue, double x, double y, double z, int xR, int yR, int zR, double size1, double size2 ,int width, int height, float bckground1, float bckground2, float bckground3, float bckground4, string tunnelId, string parentID)
        {
            this.TunnelId = tunnelId;
            this.name = name;
            ToSend = RequestCreater.TunnelSend(new
            {
                id = "scene/node/add",
                parent = parentID,
                data = new
                {
                    name = name,
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
            }, tunnelId);
        }

        public void makeUuid()
        {
            if (Uuid == null)
            {
                string temp;
                Connection.VRobjecten.TryGetValue(name, out temp);
                Uuid = temp;
            }
        }

        public void ClearPanel()
        {
            ToSend = RequestCreater.TunnelSend(new
            {
                id = "scene/panel/clear",
                data = new
                {
                    id = Uuid
                }
            }, TunnelId);
        }

        public string SwapPanel()
        {
          string send =  RequestCreater.TunnelSend(new
            {
                id = "scene/panel/swap",
                data = new
                {
                    id = Uuid
                }
            }, TunnelId);
            return send;
        }

        //0,0 10,10, 0,0,0,1 == x1, y1, x2,y2, r,g,b,a
        public string DrawLines(int widthValue, int[] lineArray)
        {
            string send = RequestCreater.TunnelSend(new
            {
                id = "scene/panel/drawlines",
                data = new
                {
                    id = Uuid,
                    width = widthValue,
                    lines = lineArray
                }
            }, TunnelId);
            return send;
        }

        public string SetClearColor(double[] kleur)
        {
           string send = RequestCreater.TunnelSend(new
            {
                id = "scene/panel/setclearcolor",
                data = new
                {
                    id = Uuid,
                    color = kleur
                }
            }, TunnelId);
            return send;
        }

        public string DrawText(string textValue, int[] positie, double sizeValue, double[] kleur, string fontValue)
        {
           string send = RequestCreater.TunnelSend(new
            {
                id = "scene/panel/drawtext",
                data = new
                {
                    id = Uuid,
                    text = textValue,
                    position = positie,
                    size = sizeValue,
                    color = kleur,
                    font = fontValue
                }
            }, TunnelId);
            return send;
        }

    }
}
