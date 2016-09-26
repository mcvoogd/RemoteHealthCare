using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRFrom_Gijs.Program
{
    class Forest
    {
        private List<Point> points = new List<Point>();

        public Forest()
        { 
            //binnenkant vierkant
            for(int i = 0; i<4; i++)
            {
                for(int j = 0; j<32 ; j++)
                {
                    points.Add(new Point(-36 + j*4, -36 + i*4));
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    points.Add(new Point(-36 + j * 4, 62 + i * 4));
                }
            }

            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    points.Add(new Point(74 + j * 4, -20 + i * 4));
                }
            }

            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    points.Add(new Point(-36 + j * 4, -20 + i * 4));
                }
            }

            //buitenkant vierkant
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 42; j++)
                {
                    points.Add(new Point(-56 + j * 4, -58 + i * 4));
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 34; j++)
                {
                    points.Add(new Point(-41 + j * 4, 86 + i * 4));
                }
            }

            for (int i = 0; i < 37; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    points.Add(new Point(-57 + j * 4, -46 + i * 4));
                }
            }

            for (int i = 0; i < 36; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    points.Add(new Point(96 + j * 4, -42 + i * 4));
                }
            }
        }

        public List<Point> getForest()
        {
            return points;
        }
    }
}
