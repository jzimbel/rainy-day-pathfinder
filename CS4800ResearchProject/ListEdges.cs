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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static List<Edge> GetEdges(int groupId)
        {
            List<Edge> edges = new List<Edge>();
            foreach (Edge e in ListEdges.EDGES)
            {
                if (e.DoorOne.GroupId.Equals(groupId)) edges.Add(e);
            }
            return edges;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public static List<Edge> GetEdges(Group group)
        {
            return GetEdges(group.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupsA"></param>
        /// <returns></returns>
        public static List<Edge> GetCut(List<Group> groupsA)
        {
            List<int> groupIds = new List<int>();
            foreach (Group ga in groupsA)
            {
                groupIds.Add(ga.Id);
            }
            return GetCut(groupIds);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupsA"></param>
        /// <returns></returns>
        public static List<Edge> GetCut(List<int> groupsA)
        {
            List<Edge> cutset = new List<Edge>();
            foreach (int ga in groupsA)
            {
                List<Edge> edgesA = GetEdges(ga);
                foreach (Edge e in edgesA)
                {
                    if (!groupsA.Contains(e.DoorTwo.GroupId))
                    {
                        cutset.Add(e);
                    }
                }
            }
            return cutset;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static double GetDistance(List<Edge> edges)
        {
            double totaldistance = 0;
            foreach (Edge e in edges)
            {
                totaldistance += e.Distance;
            }
            return totaldistance;
        }
    }
}
