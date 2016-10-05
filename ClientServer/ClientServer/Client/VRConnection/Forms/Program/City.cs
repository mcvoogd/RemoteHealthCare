using System.Collections.Generic;

namespace Client.VRConnection.Forms.Program
{
    internal class City
    {
        private readonly List<Punt> points = new List<Punt>();

        public City()
        {
            points.Add(new Punt(60, 68, 2));
        }

        public List<Punt> getCity()
        {
            return points;
        }
    }
}