using CS4800ResearchProject.Objects;
using System;
using System.Collections.Generic;

namespace CS4800ResearchProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> endpoints = PromptUser();
            Console.WriteLine(endpoints.ToString());
            List<Edge> shortestPath = PathFinder.FindPath(endpoints[0], endpoints[1]);
            foreach (Edge e in shortestPath)
            {
                Console.WriteLine(e.MapsUrl().ToString());
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static List<string> PromptUser()
        {
            List<string> buildings = ListGroups.GetBuildings();
            int startBuildingIndex = -1;
            int endBuildingIndex = -1;
            bool done = false;
            while (!done)
            {
                // list buildings, separated by group
                int i = 0;
                int g = 0;
                foreach (Group group in ListGroups.GROUPS)
                {
                    Console.WriteLine(string.Format("--Building Group {0}--", g));
                    g++;
                    foreach (string building in group.Buildings)
                    {
                        Console.WriteLine(string.Format("{0}. {1}", i, building));
                        i++;
                    }
                }

                // attempt to read index of start building from stdin
                Console.WriteLine("Please type the number of the building you are starting in, then press ENTER.");
                Console.Write("> ");
                try
                {
                    startBuildingIndex = int.Parse(Console.ReadLine());
                    if (startBuildingIndex < 0 || startBuildingIndex >= buildings.Count)
                    {
                        throw new IndexOutOfRangeException("Invalid start building index.");
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Exception thrown: {0}", e));
                    Console.WriteLine("Please enter a valid number.");
                    Console.WriteLine(); Console.WriteLine();
                    continue;
                }
                Console.WriteLine();

                // attempt to read index of destination building from stdin
                Console.WriteLine("From the same list, please type the number of your destination building, then press ENTER.");
                Console.WriteLine("Be aware that any two buildings in the same group are reachable from each other without stepping foot outdoors.");
                Console.Write("> ");
                try
                {
                    endBuildingIndex = int.Parse(Console.ReadLine());
                    if (endBuildingIndex < 0 || endBuildingIndex >= buildings.Count)
                    {
                        throw new IndexOutOfRangeException("Invalid end building index.");
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(String.Format("Exception thrown: {0}", e));
                    Console.WriteLine("Please enter a valid number.");
                    Console.WriteLine(); Console.WriteLine();
                    continue;
                }

                // make sure the start and end buildings aren't the same...
                if (startBuildingIndex == endBuildingIndex)
                {
                    Console.WriteLine("You're already at your destination!");
                    Console.WriteLine(); Console.WriteLine();
                    continue;
                }
                // ...or in the same group
                if (ListGroups.FindGroup(buildings[startBuildingIndex]).Equals(ListGroups.FindGroup(buildings[endBuildingIndex])))
                {
                    Console.WriteLine("The buildings you selected are already connected to each other; no need to travel outside.");
                    Console.WriteLine(); Console.WriteLine();
                    continue;
                }

                done = true;
            }

            if (startBuildingIndex == -1 || endBuildingIndex == -1)
            {
                throw new IndexOutOfRangeException("start or end index (or both) was not set. This really shouldn't have happened.");
            }
            return new List<string>()
            {
                buildings[startBuildingIndex],
                buildings[endBuildingIndex]
            };
        }
    }
}