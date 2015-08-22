using CS4800ResearchProject.Objects;
using System.Collections.Generic;
using System.Linq;

namespace CS4800ResearchProject
{
    /// <summary>
    /// Holds a list of shortest edges between each group. Each edge is
    /// represented once, e.g. if there is an edge (A, B) then there is no
    /// edge (B, A). Use GetEdge to get an edge between two groups.
    /// </summary>
    public static class ListEdges
    {
        private static readonly List<Edge> EDGES;

        static ListEdges()
        {
            List<Edge> edgesConstructor = new List<Edge>();
            foreach (Group ga in ListGroups.GROUPS)
            {
                foreach (Group gb in ListGroups.GROUPS)
                {
                    if (ga.Equals(gb)) continue;
                    edgesConstructor.Add(ga.ShortestEdge(gb));
                }
            }
            EDGES = edgesConstructor;
        }

        /// <summary>
        /// Returns Edge with matching Id within ListEdges.EDGES if one exists.
        /// Otherwise returns null.
        /// </summary>
        /// <param name="groupAId">Id of first group</param>
        /// <param name="groupBId">Id of second group</param>
        /// <returns></returns>
        public static Edge GetEdge(int groupAId, int groupBId)
        {
            if (groupAId == groupBId) return null;
            foreach (Edge e in EDGES)
            {
                if (e.DoorOne.GroupId == groupAId && e.DoorTwo.GroupId == groupBId)
                {
                    return e;
                }
            }
            return null;
        }

        public static Edge GetEdge(Door doorA, Door doorB)
        {
            return GetEdge(doorA.GroupId, doorB.GroupId);
        }
    }
}
