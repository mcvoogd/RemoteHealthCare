using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRConnectorForm.Program;

namespace VRConnectorForm.VRobjects
{
    class Scene
    {
        public string name { get; set; }
        public string TunnelID { get; set; }
        public string Filename { get; set; }

        public Scene(string name, string TunnelID, string Filename)
        {
            this.name = name;
            this.TunnelID = TunnelID;
            this.Filename = Filename;
        }

        public dynamic GetScene()
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/get"

            }, TunnelID);
        }

        public dynamic SaveScene(string Filename, bool Overwrite = true)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/save",
                data = new
                {
                    filename = Filename,
                    overwrite = Overwrite
                    }

                }, TunnelID);
        }

        public dynamic LoadScene(string Filename)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/load",
                data = new
                {
                    filename = Filename
                }

            }, TunnelID);
        }

        public dynamic RaycastScene(int[] Start, int[] Direction, bool Physics)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/raycast",
                data = new
                {
                    start = Start,
                    direction = Direction,
                    physics = Physics
                }

            }, TunnelID);
        }
    }
}
