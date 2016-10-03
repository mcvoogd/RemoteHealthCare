using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.VRConnection.Program
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
