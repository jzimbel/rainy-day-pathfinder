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
            return FindPath(ListGroups.FindGroup(buildingAName), ListGroups.FindGroup(buildingBName));
        }

        public static List<Edge> FindPath(Group groupA, Group groupB)
        {
            return FindPath(groupA.Id, groupB.Id);
        }

        public static List<Edge> FindPath(int groupAId, int groupBId)
        {
            double?[] distFromA = new double?[ListGroups.GROUPS.Count]; // each element is current known shortest distance from A
            int?[] prevGroupId = new int?[ListGroups.GROUPS.Count]; // each element is the current known previous node

            List<int> groupsCovered = new List<int>();

            // initialize groupA's elements
            distFromA[groupAId] = 0;
            prevGroupId[groupAId] = null;

            // initialize the rest of the group's elements in the lists
            foreach (Group g in ListGroups.GROUPS)
            {
                if (g.Id != groupAId)
                {
                    distFromA[g.Id] = null;
                    prevGroupId[g.Id] = null;
                }
                groupsCovered.Add(g.Id);
            }

            // running dijkstra's
            while (groupsCovered.Count != 0)
            {
                // finding the group with the shortest distance to GroupA, first one will be A
                int? groupWithShortestDist = null;
                foreach (int groupId in groupsCovered)
                {
                    if (distFromA[groupId] == null) // if distance is undefined skip
                        continue;
                    if (groupWithShortestDist == null)
                    {
                        groupWithShortestDist = groupId;
                        continue;
                    }
                    if (distFromA[groupId] < distFromA[(int)groupWithShortestDist])
                    {
                        groupWithShortestDist = groupId;
                    }
                }
                // groupWithShortestDist should now be just that, the group with the current shortest distance to A.

                groupsCovered.Remove((int)groupWithShortestDist);

                foreach (Edge e in ListEdges.GetEdges((int)groupWithShortestDist))
                {
                    double alt = (double)distFromA[(int)groupWithShortestDist] + e.Distance;
                    if (distFromA[e.DoorTwo.GroupId] == null)
                    {
                        distFromA[e.DoorTwo.GroupId] = alt;
                        prevGroupId[e.DoorTwo.GroupId] = groupWithShortestDist;
                        continue;
                    }
                    if (alt < distFromA[e.DoorTwo.GroupId])
                    {
                        distFromA[e.DoorTwo.GroupId] = alt;
                        prevGroupId[e.DoorTwo.GroupId] = groupWithShortestDist;
                        continue;
                    }
                }
            }
            // reading output into list<edge>
            List<Edge> shortestPath = new List<Edge>();
            int target = groupBId;
            while (prevGroupId[target] != null)
            {
                shortestPath.Add(ListEdges.GetEdge((int)prevGroupId[target], target));
                target = (int)prevGroupId[target];
            }
            return shortestPath;
        }
    }
}
