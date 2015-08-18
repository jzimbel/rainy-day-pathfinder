using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4800ResearchProject
{
    public class Group
    {
        public List<Door> Doors;

        public Group (Guid Id)
        {

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
