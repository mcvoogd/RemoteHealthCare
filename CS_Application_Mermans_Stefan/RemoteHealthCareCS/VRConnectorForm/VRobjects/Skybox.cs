using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRConnectorForm.Program;

namespace VRConnectorForm.VRobjects
{
    class Skybox
    {
        public string name { get; set; }
        public string TunnelID { get; set; }

        public Skybox(string name, string TunnelID)
        {
            this.name = name;
            this.TunnelID = TunnelID;
        }

        public string SetTime(int Time)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/skybox/settime",
                data = new
                {
                    time = Time
                }
            }, TunnelID);
        }

        public string Update()
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/skybox/update",
                
            }, TunnelID);
        }
    }
}
