using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRFrom_Gijs.Program
{
    class Punt
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Punt(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}
