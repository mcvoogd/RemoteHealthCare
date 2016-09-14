using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRConnectorForm.Program;

namespace VRConnectorForm.VRobjects
{
    class Route
    {
        public string name { get; set; }
        public string TunnelID { get; set; }

        public Route(string name, string TunnelID)
        {
            this.name = name;
            this.TunnelID = TunnelID;
        }

        //The inputted array should contain the format given in the document. See also: { "pos" : [ x, x, x  ],	"dir" :		[ x, x, x] }
        public dynamic Add(string[] routePoint)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "route/add",
                data = new
                {
                    nodes = routePoint
                }
            }, TunnelID);
        }

        public dynamic Update()
        {
            return RequestCreater.TunnelSend(new
            {
                id = "route/update",
            }, TunnelID);
        }

        public dynamic Delete(string uuid)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "route/delete",
                data = new
                {
                    id = uuid
                }

            }, TunnelID);
        }

        public dynamic Follow(String routeId, String nodeId, double uuspeed, double uuoffset, String uurotate, int[] uurotateOffset, int[] uupositionOffset)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "route/follow",
                data = new
               {
                    route = routeId,
                    node = nodeId,
                    speed = uuspeed,
                    offset = uuoffset,
                    rotate = uurotate,
                    rotateOffset = uurotateOffset,
                    positionOffset = uupositionOffset

               }
            }, TunnelID);
        }
        
        
    }
}
