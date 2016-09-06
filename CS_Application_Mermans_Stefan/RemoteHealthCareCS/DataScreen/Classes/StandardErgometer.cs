using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScreen
{
    interface StandardErgometer
    {
        int pulse { get; set; }
        int rotations { get; set; }
        int speed { get; set; }
        int power { get; set; }
        int burned { get; set; }
        int time { get; set; }
        int reachedpower { get; set; }
        int distance { get; set; }

        void connect();
        void disconnect();

    }
}
