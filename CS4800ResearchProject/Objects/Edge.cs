using System;
using System.Collections.Generic;

namespace CS4800ResearchProject.Objects
{
    public class Edge
    {
        public readonly Door DoorOne;
        public readonly Door DoorTwo;
        public readonly double Distance;

        public Edge(Door doorOne, Door doorTwo)
        {
            DoorOne = doorOne;
            DoorTwo = doorTwo;
            Distance = DoorOne.Distance(DoorTwo);
        }

        public Uri MapsUrl(bool direction)
        {
            if (direction)
                return new Uri(String.Format("https://www.google.com/maps/dir/{0},{1}/{2},{3}/", DoorOne.Latitude, DoorOne.Longitude, DoorTwo.Latitude, DoorTwo.Longitude));
            else
                return new Uri(String.Format("https://www.google.com/maps/dir/{0},{1}/{2},{3}/", DoorTwo.Latitude, DoorTwo.Longitude, DoorOne.Latitude, DoorOne.Longitude));
        }
    }
}
