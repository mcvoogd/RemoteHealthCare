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
        public string name { get; set; }
        public string TunnelID { get; set; }

        public Road(string name, string TunnelID)
        {
            this.name = name;
            this.TunnelID = TunnelID;
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
            }, TunnelID);
        }

        public dynamic Delete()
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/road/delete",

            }, TunnelID);
        }
    }
}
