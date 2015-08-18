using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4800ResearchProject
{
    public class Door
    {
        public LatLng Location;

        public Door (LatLng location)
        {
            this.Location = location;
        }

        public double Distance (Door d)
        {
            return Distance(this, d);
        }

        public static double Distance (Door d1, Door d2)
        {
            return LatLng.Distance(d1.Location, d2.Location);
        }
    }
}
