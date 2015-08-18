using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4800ResearchProject
{
    public static class ListGroups
    {
        private static string csvPath = "..\\..\\doors.csv";
        public static List<Group> Groups;

        static ListGroups()
        {
            var csv = from line in File.ReadAllLines(csvPath).Skip(1)
                    let columns = line.Split(',')
                    select new
                    {
                        DoorId = Guid.Parse(columns[0]),
                        Building = columns[1],
                        GroupId = Guid.Parse(columns[2]),
                        Latitude = double.Parse(columns[3]),
                        Longitude = double.Parse(columns[4])
                    };
            foreach (var door in csv)
            {
                if (!Groups.Select(g => { return g.Id; }).ToList().Contains(door.GroupId))
                {
                    Door d = new Door()
                    Group g = new Group(door.GroupId, new List<Building>());
                    Building b = new Building(new Guid(), door.Building, new List<Door>());
                    
                    g.buildings.Add(door.Building);
                }
            }
            Console.WriteLine(csv.ToString());
        }
    }
}
