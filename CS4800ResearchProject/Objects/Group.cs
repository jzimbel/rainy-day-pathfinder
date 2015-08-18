using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4800ResearchProject
{
    public class Group
    {
        public Guid Id;
        public List<Building> buildings;

        public List<Door> doors
        {
            get
            {
                List<Door> accdoors = new List<Door>();
                foreach (Building b in this.buildings)
                {
                    accdoors.AddRange(b.Doors);
                }
                return accdoors;
            }
        }

        public Group (Guid Id, List<Building> buildings)
        {
            this.Id = Id;
            this.buildings = buildings;
        }

        public Edge ShortestEdge (Group g)
        {
            return ShortestEdge(this, g);
        }

        public static Edge ShortestEdge(Group ga, Group gb)
        {
            Edge e = new Edge();
            foreach (Door d_a in ga.doors)
            {
                foreach (Door d_b in gb.doors)
                {
                    Edge tempE = new Edge(d_a, d_b, ga.Id, gb.Id, d_a.Distance(d_b));
                    if (e == new Edge())
                    {
                        e = tempE;
                        continue;
                    }
                    if (e.Distance > tempE.Distance)
                    {
                        e = tempE;
                    }
                }
            }
            return e;
        }
    }
}
