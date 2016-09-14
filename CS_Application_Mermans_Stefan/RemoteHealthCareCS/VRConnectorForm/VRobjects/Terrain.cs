using System;
using System.Collections.Generic;
using System.Drawing;
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
            _connection = connection;

            int[] heightmap = HeightMapGenerator.GenerateHeightmap();
            AddTerrain(new []{256,256},heightmap);
        }

        public void AddTerrain(int[] mapSize, int[] mapHeight)
        {
            var request = RequestCreater.TunnelSend(new
            {
                id = "scene/terrain/add",
                data = new
                {
                    size = mapSize, 
                    heights = mapHeight
                }
            }, _tunnelId);
//            Console.WriteLine(request);
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

        public void GetHeight(int[][,] positions)
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

    internal static class HeightMapGenerator
    {
        public static int[] GenerateHeightmap()
        {
            var heightMap = Image.FromFile("C:/Projects/VisualRemoteHealthCare/CS_Application_Mermans_Stefan/RemoteHealthCareCS/VRConnectorForm/res/map.jpg");
            var bitHeigthMap = new Bitmap(heightMap, 256, 256);
            var pixels = new int[256 * 256];
            for (int countRow = 0; countRow < 256; countRow++)
            {
                for (int countCollum = 0; countCollum < 256; countCollum++)
                {
                    Color c = bitHeigthMap.GetPixel(countRow, countCollum);
                    pixels[countRow * countCollum] = colorToInt(c);
                }
            }
            return pixels;
        }

        private static int colorToInt(Color c)
        {
            return Convert.ToInt32(colorToHex(c), 16);
        }

        private static string colorToHex(Color c)
        {
            return c.R.ToString("X2");
        }
    }
}
