using System.Collections.Generic;

namespace Client.VRConnection.Forms.Program
{
    internal class Forest
    {
        private readonly List<Punt> points = new List<Punt>();

        public Forest()
        {
            points.Add(new Punt(30, 72, 2));
            points.Add(new Punt(34, 73, 2));
            points.Add(new Punt(32, 70, 2));

            points.Add(new Punt(-20, -47, 4));
            points.Add(new Punt(-22, -45, 5));
        }

        public List<Punt> getForest()
        {
            return points;
        }
    }
}