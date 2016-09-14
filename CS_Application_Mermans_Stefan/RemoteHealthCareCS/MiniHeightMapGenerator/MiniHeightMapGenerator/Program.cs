using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MiniHeightMapGenerator
{
    class Program
    {
        Image heightMap;
        Bitmap bitHeigthMap;
        int[] pixels;
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            heightMap = Image.FromFile("C:/Users/Menno/Documents/Visual Studio 2015/Projects/MiniHeightMapGenerator/Resources/TestMap3.png");
            bitHeigthMap = new Bitmap(heightMap, 256, 256);
            pixels = new int[256 * 256];
            for (int countRow = 0; countRow < 256; countRow++)
            {
                for (int countCollum = 0; countCollum < 256; countCollum++)
                {
                    Color c = bitHeigthMap.GetPixel(countRow, countCollum);
                    pixels[countRow * countCollum] = colorToInt(c);
                }
            }
        }

        private int colorToInt(Color c)
        {
            return Convert.ToInt32(colorToHex(c), 16);
        }

        private static String colorToHex(Color c)
        {
            return  c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
    }
}
