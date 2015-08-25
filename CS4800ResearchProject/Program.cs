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
            if (endpoints == null) Exit();
            List<Edge> shortestPath = PathFinder.FindPath(endpoints[0], endpoints[1]);
            foreach (Edge e in shortestPath)
            {
                Console.WriteLine(e.MapsUrl().ToString());
            }
            Exit();
        }

        /// <summary>
        /// Prompts the user for their start and destination. If an outdoor route needs
        /// to be found for their selected points, returns a list of two strings. The
        /// first string is the starting building; the second is the destination building.
        /// If no outdoor route needs to be found and they elect to end, returns null.
        /// </summary>
        /// <returns></returns>
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
                bool first = true;
                foreach (Group group in ListGroups.GROUPS)
                {
                    if (!first) Console.WriteLine();
                    else first = false;
                    Console.WriteLine(string.Format("--Building Group {0}--", g));
                    g++;
                    foreach (string building in group.Buildings)
                    {
                        Console.WriteLine(string.Format("{0}. {1}", i+1, building));
                        i++;
                    }
                }

                try
                {
                    // attempt to read index of start building from stdin
                    Console.WriteLine("Please type the number of the building you are starting in, then press ENTER.");
                    Console.Write("> ");
                    startBuildingIndex = int.Parse(Console.ReadLine()) - 1;
                    if (startBuildingIndex < 0 || startBuildingIndex >= buildings.Count)
                    {
                        throw new IndexOutOfRangeException("Invalid start building index.");
                    }
                    Console.WriteLine();

                    // attempt to read index of destination building from stdin
                    Console.WriteLine("From the same list, please type the number of your destination building, then press ENTER.");
                    Console.WriteLine("Be aware that any two buildings in the same group are reachable from each other without stepping foot outdoors.");
                    Console.Write("> ");
                    endBuildingIndex = int.Parse(Console.ReadLine()) - 1;
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
                    Console.WriteLine("Would you like to navigate somewhere else? Answer yes or no.");
                    Console.Write("> ");
                    string response = Console.ReadLine().ToLower();
                    if (response.Equals("yes") || response.Equals("y"))
                    {
                        Console.WriteLine(); Console.WriteLine();
                        continue;
                    }
                    else return null;
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

        private static void Exit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            System.Environment.Exit(0);
        }
    }
}