using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4800ResearchProject
{
    public class Edge
    {
        public Door StartDoor;
        public Door EndDoor;
        public Guid StartGroupId;
        public Guid EndGroupId;
        public double Distance;

        public string MapsUrl
        {
            get
            {
                return String.Format("https://www.google.com/maps/dir/{0},{1}/{2},{3}/",
                                StartDoor.Location.Latitude, StartDoor.Location.Longitude, EndDoor.Location.Latitude, EndDoor.Location.Longitude);
            }
        }

        public Edge()
        {

        }

        public Edge(Door startDoor, Door endDoor, Guid startGroupId, Guid endGroupId, double distance)
        {
            StartDoor = startDoor;
            EndDoor = endDoor;
            StartGroupId = startGroupId;
            EndGroupId = endGroupId;
            Distance = distance;
        }
    }
}

// first one start , 2nd dest. (0,1 start | 2,3 dest)
// https://www.google.com/maps/dir/42.338843,-71.092052/42.338628,-71.091487/
// https://www.google.com/maps/dir/{0},{1}/{2},{3}/