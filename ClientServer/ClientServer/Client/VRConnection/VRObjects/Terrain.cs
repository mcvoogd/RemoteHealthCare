using System.Drawing;
using Client.VRConnection.Forms.Program;

namespace Client.VRConnection.VRObjects
{
    internal class Terrain
    {
        private readonly Forms.Program.Connection _connection;
        private readonly string _tunnelId;

        public Terrain(string tunnelId, Forms.Program.Connection connection)
        {
            _tunnelId = tunnelId;
            _connection = connection;

            var heightmap = HeightMapGenerator.GenerateHeightmap();
            AddTerrain(new[] {256, 256}, heightmap);
        }

        public string UUID { get; }

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
            }, _tunnelId);
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
                    positions
                }
            }, _tunnelId);
            _connection.SendMessage(request);
        }
    }

    internal static class HeightMapGenerator
    {
        public static double[] GenerateHeightmap()
        {
            var heightMap = Image.FromFile(@"..\..\res/heightmaptest2.jpg");
            var bitHeigthMap = new Bitmap(heightMap, 256, 256);
            var pixels = new double[256*256];
            for (var countRow = 0; countRow < 256; countRow++)
                for (var countCollum = 0; countCollum < 256; countCollum++)
                {
                    var c = bitHeigthMap.GetPixel(countCollum, countRow);
                    pixels[countRow + 256*countCollum] = colorToInt(c);
                }
            return pixels;
        }

        private static double colorToInt(Color c)
        {
            return (double) c.B/8;
        }
    }
}