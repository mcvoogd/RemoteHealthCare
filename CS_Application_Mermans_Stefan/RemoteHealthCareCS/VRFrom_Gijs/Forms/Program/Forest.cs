﻿using System.Collections.Generic;

namespace VRFrom_Gijs.Program
{
    class Forest
    {
        private List<Punt> points = new List<Punt>();

        public Forest()
        {
            points.Add(new Punt(30, 72, 2));
            points.Add(new Punt(34, 73, 2));
            points.Add(new Punt(32, 70, 2));
        }

        public List<Punt> getForest()
        {
            return points;
        }
    }
}