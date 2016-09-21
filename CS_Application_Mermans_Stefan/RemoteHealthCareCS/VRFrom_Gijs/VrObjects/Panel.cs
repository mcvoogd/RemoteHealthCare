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

        public Panel(string name, int scaleValue, int x, int y, int z, int xR, int yR, int zR, int size1, int size2 ,int width, int height, int bckground1, int bckground2, int bckground3, int bckground4, string tunnelId)
        {
            this.TunnelId = tunnelId;
            ToSend = RequestCreater.TunnelSend(new
            {
                id = "scene/node/add",
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

        public void ClearPanel()
        {
            RequestCreater.TunnelSend(new
            {
                id = "scene/panel/clear",
                data = new
                {
                    id = Uuid
                }
            }, TunnelId);
        }

        public void SwapPanel()
        {
            RequestCreater.TunnelSend(new
            {
                id = "scene/panel/swap",
                data = new
                {
                    id = Uuid
                }
            }, TunnelId);
        }

        //0,0 10,10, 0,0,0,1 == x1, y1, x2,y2, r,g,b,a
        public void DrawLines(int widthValue, int[] lineArray)
        {
            RequestCreater.TunnelSend(new
            {
                id = "scene/panel/drawlines",
                data = new
                {
                    id = Uuid,
                    width = widthValue,
                    lines = lineArray
                }
            }, TunnelId);
        }

        public void SetClearColor(int[] kleur)
        {
            RequestCreater.TunnelSend(new
            {
                id = "scene/panel/setclearcolor",
                data = new
                {
                    id = Uuid,
                    color = kleur
                }
            }, TunnelId);
        }

        public void DrawText(string textValue, int[] positie, double sizeValue, int[] kleur, string fontValue)
        {
            RequestCreater.TunnelSend(new
            {
                id = "scene/panel/setclearcolor",
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
        }

    }
}
