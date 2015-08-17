using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4800ResearchProject
{
    public static class ListEdges
    {
        public static List<Edge> Edges;

        static ListEdges()
        {
            Edges = new List<Edge>();
            foreach (Group ga in ListGroups.Groups)
            {
                List<Group> groups_ga = ListGroups.Groups;
                groups_ga.Remove(ga);
                foreach (Group gb in groups_ga)
                {
                    Edges.Add(ga.ShortestEdge(gb));
                }
            }
        }
    }
}
