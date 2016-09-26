using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRFrom_Gijs.Program;

namespace VRFrom_Gijs.VrObjects
{
    class Terrain
    {
        private readonly string _tunnelId;
        private readonly Connection _connection;
        public string UUID { get;}

        public Terrain(string tunnelId, Connection connection)
        {
            _tunnelId = tunnelId;
            _connection = connection;

            double[] heightmap = HeightMapGenerator.GenerateHeightmap();
            AddTerrain(new []{256,256},heightmap);
        }

        public void AddTerrain(int[] mapSize, double[] mapHeight)
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
           _connection.SendMessage(request);
        }

        public void UpdateTerrain(string command)
        {
            var request = RequestCreater.TunnelSend(new
            {
                id = "scene/terrain/update",
                data = command
            },_tunnelId);
            _connection.SendMessage(request);
        }

        public void DeleteTerrain(string command)
        {
            var request = RequestCreater.TunnelSend(new
            {
                id = "scene/terrain/delete",
                data = command
            }, _tunnelId);
            _connection.SendMessage(request);
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
           _connection.SendMessage(request);
        }

    }

    internal static class HeightMapGenerator
    {
        public static double[] GenerateHeightmap()
        {
            var heightMap = Image.FromFile(@"..\..\res/testmap.jpg");
            var bitHeigthMap = new Bitmap(heightMap, 256, 256);
            var pixels = new double[256 * 256];
            for (int countRow = 0; countRow < 256; countRow++)
            {
                for (int countCollum = 0; countCollum < 256; countCollum++)
                {
                    Color c = bitHeigthMap.GetPixel(countCollum, countRow);
                    pixels[countRow + 256 * countCollum] = colorToInt(c);
                }
            }
            return pixels;
        }

        private static double colorToInt(Color c)
        {
            return (double)c.B / 5;
        }
    }
}
