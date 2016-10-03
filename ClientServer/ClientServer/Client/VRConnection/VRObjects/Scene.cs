using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.VRConnection.Forms.Program;

namespace Client.VRConnection.VRObjects
{
    class Scene
    {
        public string Name { get; set; }
        public string TunnelId { get; set; }
        public string Filename { get; set; }

        public Scene(string name, string tunnelId, string filename)
        {
            Name = name;
            TunnelId = tunnelId;
            Filename = filename;
        }

        public dynamic GetScene()
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/get"

            }, TunnelId);
        }

        public dynamic SaveScene(string filename, bool overwrite = true)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/save",
                data = new
                {
                    filename = filename,
                    overwrite = overwrite
                    }

                }, TunnelId);
        }

        public dynamic LoadScene(string filename)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/load",
                data = new
                {
                    filename = filename
                }

            }, TunnelId);
        }

        public dynamic RaycastScene(int[] start, int[] direction, bool physics)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/raycast",
                data = new
                {
                    start = start,
                    direction = direction,
                    physics = physics
                }

            }, TunnelId);
        }
    }
}
