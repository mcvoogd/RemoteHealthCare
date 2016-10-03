using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.VRConnection.Forms.Program
{
    class City
    {
        private List<Punt> points = new List<Punt>();

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
