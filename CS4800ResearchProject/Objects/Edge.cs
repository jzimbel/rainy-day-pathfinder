using System;

namespace CS4800ResearchProject.Objects
{
    public class Edge
    {
        public Door StartDoor;
        public Door EndDoor;
        public double Distance;

        public string MapsUrl
        {
            get
            {
                // e.g. https://www.google.com/maps/dir/42.338843,-71.092052/42.338628,-71.091487/
                return String.Format("https://www.google.com/maps/dir/{0},{1}/{2},{3}/",
                                StartDoor.Location.Latitude, StartDoor.Location.Longitude, EndDoor.Location.Latitude, EndDoor.Location.Longitude);
            }
        }

        public Edge(Door startDoor, Door endDoor, double distance)
        {
            StartDoor = startDoor;
            EndDoor = endDoor;
            Distance = distance;
        }
    }
}
