using CS4800ResearchProject.Objects;
using System;

namespace CS4800ResearchProject
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Debug.WriteLine(ListGroups.GROUPS[0]);
            int doorCount = 0;
            foreach (Group g in ListGroups.GROUPS)
            {
                doorCount += g.Doors.Count;
            }
            System.Diagnostics.Debug.WriteLine("total door count: " + doorCount);
            System.Diagnostics.Debug.WriteLine(ListEdges.GetEdge(0, 15));
            System.Diagnostics.Debug.WriteLine(ListEdges.GetEdge(15, 0));
        }
    }
}
