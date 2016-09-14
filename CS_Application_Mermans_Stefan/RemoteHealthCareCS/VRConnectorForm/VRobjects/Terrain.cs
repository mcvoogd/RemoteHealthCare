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
        private readonly string _tunnelId;
        private readonly Connection _connection;

        public Terrain(string tunnelId, Connection connection)
        {
            _tunnelId = tunnelId;
        }

        public void AddTerrain(int[] size, int[] height)
        {
            var request = RequestCreater.TunnelSend(new
            {
                id = "scene/terrain/add",
                data = new
                {
                    size = size, 
                    heights = height
                }
            }, _tunnelId);
           _connection.sendMessage(request);
        }

        public void UpdateTerrain(string command)
        {
            var request = RequestCreater.TunnelSend(new
            {
                id = "scene/terrain/update",
                data = command
            },_tunnelId);
            _connection.sendMessage(request);
        }

        public void DeleteTerrain(string command)
        {
            var request = RequestCreater.TunnelSend(new
            {
                id = "scene/terrain/delete",
                data = command
            }, _tunnelId);
            _connection.sendMessage(request);
        }

        public void GetHeight(int[][] positions)
        {
            var request = RequestCreater.TunnelSend(new
            {
                id = "scene/terrain/getheight",
                data = new
                {
                    positions = positions
                }
            }, _tunnelId);
           _connection.sendMessage(request);
        }

    }
}
