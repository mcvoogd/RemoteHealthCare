﻿using Client.VRConnection.Forms.Program;

namespace Client.VRConnection.VRObjects
{
    public class Panel
    {
        public Panel(string name, int scaleValue, double x, double y, double z, int xR, int yR, int zR, double size1,
            double size2, int width, int height, float bckground1, float bckground2, float bckground3, float bckground4,
            string tunnelId, string parentID)
        {
            TunnelId = tunnelId;
            Name = name;
            ToSend = RequestCreater.TunnelSend(new
            {
                id = "scene/node/add",
                parent = parentID,
                data = new
                {
                    name = Name,
                    components = new
                    {
                        transform = new
                        {
                            position = new[] {x, y, z},
                            scale = scaleValue,
                            rotation = new[] {xR, yR, zR}
                        },
                        panel = new
                        {
                            size = new[] {size1, size2},
                            resolution = new[] {width, height},
                            background = new[] {bckground1, bckground2, bckground3, bckground4}
                        }
                    }
                }
            }, tunnelId);
        }

        public string Uuid { get; set; }
        public string ToSend { get; set; }
        public string TunnelId { get; }
        public string Name { get; set; }

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

        public void SwapPanel()
        {
            ToSend = RequestCreater.TunnelSend(new
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
            ToSend = RequestCreater.TunnelSend(new
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

        public void SetClearColor(double[] kleur)
        {
            ToSend = RequestCreater.TunnelSend(new
            {
                id = "scene/panel/setclearcolor",
                data = new
                {
                    id = Uuid,
                    color = kleur
                }
            }, TunnelId);
        }

        public void DrawText(string textValue, int[] positie, double sizeValue, double[] kleur, string fontValue)
        {
            ToSend = RequestCreater.TunnelSend(new
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
        }
    }
}