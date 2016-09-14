using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRConnectorForm.Program;

namespace VRConnectorForm.VRobjects
{
    class Terrain
    {
        public Terrain(string tunnelId, Connection connection)
        {
            
        }

        private void addTerrain(int[] size, int[] height, string tunnelId)
        {
            RequestCreater.TunnelSend(new
            {
                id = "scene/terrain/add",
                data = new
                {
                    size = size, 
                    heights = height
                }
            }, tunnelId);
        }

        private void updateTerrain(string command)
        {
            
        }
    }
}
