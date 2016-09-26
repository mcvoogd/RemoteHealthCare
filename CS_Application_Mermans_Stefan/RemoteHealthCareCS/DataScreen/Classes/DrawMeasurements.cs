using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DataScreen.Classes.ClientCas.Classes;

namespace DataScreen.Classes
{
    class DrawMeasurements
    {
        private List<Measurement> measurements;
        private Point point1, point2;

        public DrawMeasurements(List<Measurement> measurements)
        {
            this.measurements = measurements;
        }

        public enum Graph
        {
            LINEGRAPH,
            BARGRAPH
        }

        public void drawPulse(Graph sortGraph)
        {
            for (int i = 0; i < measurements.Count; i++)
            {
                Point point = new Point(measurements[i].Pulse, i);

                switch (sortGraph)
                {
                    case Graph.BARGRAPH:
                        drawBar(point);
                        break;
                    case Graph.LINEGRAPH:
                        drawLine(point);
                        break;
                }
            }

            point1 = new Point(0, 0);
        }

        public void drawRotations(Graph sortGraph)
        {
            for (int i = 0; i < measurements.Count - 1; i++)
            {
                Point point = new Point(measurements[i].Rotations, i);

                switch (sortGraph)
                {
                    case Graph.BARGRAPH:
                        drawBar(point);
                        break;
                    case Graph.LINEGRAPH:
                        drawLine(point);
                        break;
                }
            }
        }

        public void drawSpeed(Graph sortGraph)
        {
            for (int i = 0; i < measurements.Count - 1; i++)
            {
                Point point = new Point(measurements[i].Speed, i);

                switch (sortGraph)
                {
                    case Graph.BARGRAPH:
                        drawBar(point);
                        break;
                    case Graph.LINEGRAPH:
                        drawLine(point);
                        break;
                }
            }
        }

        public void drawPower(Graph sortGraph)
        {
            for (int i = 0; i < measurements.Count - 1; i++)
            {
                Point point = new Point(measurements[i].Power, i);

                switch (sortGraph)
                {
                    case Graph.BARGRAPH:
                        drawBar(point);
                        break;
                    case Graph.LINEGRAPH:
                        drawLine(point);
                        break;
                }
            }
        }

        public void drawBurned(Graph sortGraph)
        {
            for (int i = 0; i < measurements.Count - 1; i++)
            {
                Point point = new Point((int)measurements[i].Burned, i);

                switch (sortGraph)
                {
                    case Graph.BARGRAPH:
                        drawBar(point);
                        break;
                    case Graph.LINEGRAPH:
                        drawLine(point);
                        break;
                }
            }
        }

        public void drawReachedPower(Graph sortGraph)
        {
            for (int i = 0; i < measurements.Count - 1; i++)
            {
                Point point = new Point(measurements[i].ReachedPower, i);

                switch (sortGraph)
                {
                    case Graph.BARGRAPH:
                        drawBar(point);
                        break;
                    case Graph.LINEGRAPH:
                        drawLine(point);
                        break;
                }
            }
        }

        public void drawDistance(Graph sortGraph)
        {
            for (int i = 0; i < measurements.Count - 1; i++)
            {
                Point point = new Point((int)measurements[i].Distance, i);

                switch (sortGraph)
                {
                    case Graph.BARGRAPH:
                        drawBar(point);
                        break;
                    case Graph.LINEGRAPH:
                        drawLine(point);
                        break;
                }
            }
        }

        private void drawLine(Point point)
        {
            point1 = point2;
            point2 = point;

            Console.WriteLine("Point 1:");
            Console.WriteLine("x: " + point1.X);
            Console.WriteLine("y: " + point1.Y);
            Console.WriteLine("Point 2:");
            Console.WriteLine("x: " + point2.X);
            Console.WriteLine("y: " + point2.Y);
            Console.WriteLine("--------------------------");
        }

        private void drawBar(Point point)
        {
            Console.WriteLine("Point:");
            Console.WriteLine("x: " + point.X);
            Console.WriteLine("y: " + point.Y);
            Console.WriteLine("--------------------------");
        }
    }
}
