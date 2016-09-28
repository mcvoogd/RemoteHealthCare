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
            
        }

        public List<Point> getForest()
        {
            return points;
        }
    }
}
