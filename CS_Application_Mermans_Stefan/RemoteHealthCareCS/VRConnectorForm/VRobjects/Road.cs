using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRConnectorForm.Program;

namespace VRConnectorForm.VRobjects
{
    class Road
    {
        public string Name { get; set; }
        public string TunnelId { get; set; }

        public Road(string name, string tunnelId)
        {
            Name = name;
            TunnelId = tunnelId;
        }

        public dynamic Add(string uuid)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/road/add",
                data = new
                {
                    route = uuid
                }
            }, TunnelId);
        }

        public dynamic Delete()
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/road/delete",

            }, TunnelId);
        }
    }
}
