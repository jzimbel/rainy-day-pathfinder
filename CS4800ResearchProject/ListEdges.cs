using CS4800ResearchProject.Objects;
using System.Collections.Generic;
using System.Linq;

namespace CS4800ResearchProject
{
    /// <summary>
    /// Holds a list of shortest edges between each group.
    /// </summary>
    public static class ListEdges
    {
        public static readonly List<Edge> EDGES;

        static ListEdges()
        {
            List<Edge> edgesConstructor = new List<Edge>();
            for (int i = 0; i < ListGroups.GROUPS.Count(); i++)
            {
                Group groupA = ListGroups.GROUPS[i];
                for (int j = i+1; j < ListGroups.GROUPS.Count(); j++)
                {
                    Group groupB = ListGroups.GROUPS[j];
                    edgesConstructor.Add(groupA.ShortestEdge(groupB));
                }
            }
            EDGES = edgesConstructor;
        }

        /// <summary>
        /// Returns Edge with matching Id within ListEdges.EDGES if one exists.
        /// Otherwise returns null.
        /// </summary>
        /// <param name="groupA"></param>
        /// <param name="groupB"></param>
        /// <returns></returns>
        static Edge FindEdge(Group groupA, Group groupB)
        {
            SortedSet<int> groupIds = new SortedSet<int>() { groupA.Id, groupB.Id };
            foreach (Edge e in EDGES)
            {
                SortedSet<int> edgeGroupIds = new SortedSet<int>() { e.StartDoor.GroupId, e.EndDoor.GroupId };
                if (groupIds.Equals(edgeGroupIds)) return e;
            }
            return null;
        }

        static Edge FindEdge(Door doorA, Door doorB)
        {
            return FindEdge(ListGroups.FindGroup(doorA.GroupId), ListGroups.FindGroup(doorB.GroupId));
        }
    }
}
