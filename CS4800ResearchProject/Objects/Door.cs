using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4800ResearchProject
{
    public class Door
    {
        public Guid Id;
        public LatLng LatLng;
        public Guid Group_Id;
        public Guid Building_Id;

        public Door (Guid id, LatLng latlng, Guid group_id, Guid building_id)
        {
            Id = id;
            LatLng = latlng;
            Group_Id = group_id;
            Building_Id = building_id;
        }

        public double Distance (Door d)
        {
            return Distance(this, d);
        }

        public static double Distance (Door d1, Door d2)
        {
            return LatLng.Distance(d1.LatLng, d2.LatLng);
        }
    }
}
