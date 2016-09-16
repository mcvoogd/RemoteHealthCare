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
        public string Name { get; set; }
        public string TunnelId { get; set; }

        public Skybox(string name, string tunnelId)
        {
            Name = name;
            TunnelId = tunnelId;
        }

        public string SetTime(double time)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/skybox/settime",
                data = new
                {
                    time = time
                }
            }, TunnelId);
        }

        public string Update()
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/skybox/update",
                
            }, TunnelId);
        }
    }
}
