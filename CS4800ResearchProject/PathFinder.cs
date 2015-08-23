using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS4800ResearchProject.Objects;

namespace CS4800ResearchProject
{
    public static class PathFinder
    {
        public static List<Edge> FindPath(string buildingAName, string buildingBName)
        {
            return FindPath(ListGroups.FindGroup(buildingAName), ListGroups.FindGroup(buildingAName));
        }

        public static List<Edge> FindPath(Group groupA, Group groupB)
        {
            List<int> finishedGroups = new List<int>();

            Dictionary<int, List<Edge>> shortestPathToGroup = new Dictionary<int, List<Edge>>();
            shortestPathToGroup.Add(groupA.Id, new List<Edge>());

            while (!finishedGroups.Contains(groupB.Id)) // break after checking the final node.
            {
                foreach(Group g in ListGroups.GROUPS)
                {
                    if (finishedGroups.Contains(g.Id))
                        continue;
                    if (!shortestPathToGroup.ContainsKey(g.Id))
                        continue;
                    foreach (Edge e in ListEdges.GetEdges(g))
                    {
                        List<Edge> newPath = new List<Edge>(); // get the new path from the groupA node, including the current edge
                        newPath.Concat(shortestPathToGroup[g.Id]);
                        newPath.Add(e);

                        if (!shortestPathToGroup.ContainsKey(e.DoorTwo.GroupId)) // if the node at the end of the edge is inf
                        {
                            shortestPathToGroup[e.DoorTwo.GroupId] = newPath;
                            continue;
                        }

                        if (ListEdges.GetDistance(newPath) < ListEdges.GetDistance(shortestPathToGroup[e.DoorTwo.GroupId])) // if the new path to the node at the end of the edge is shorter than the current path to the node at the end of the edge
                        {
                            shortestPathToGroup[e.DoorTwo.GroupId] = newPath;
                            finishedGroups.Remove(e.DoorTwo.GroupId); // new distance to the node at the end of the current edge, so we have to recheck that node
                        }
                    }
                    finishedGroups.Add(g.Id); // mark the current node as being checked
                }
            }
            return shortestPathToGroup[groupB.Id];
        }
    }
}
