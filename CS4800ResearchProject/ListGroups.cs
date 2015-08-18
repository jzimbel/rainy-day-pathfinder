using CS4800ResearchProject.Objects;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CS4800ResearchProject
{
    public static class ListGroups
    {
        private static readonly string CSVPATH = "..\\..\\doors.csv";

        public static readonly List<CsvRow> CSV;
        public static readonly List<Group> GROUPS;

        static ListGroups()
        {
            List<Group> groupsConstructor = new List<Group>();
            CSV = (from line in File.ReadAllLines(CSVPATH).Skip(1)
                    let columns = line.Split(',')
                    select new CsvRow
                    {
                        DoorId = int.Parse(columns[0]),
                        Building = columns[1],
                        GroupId = int.Parse(columns[2]),
                        Latitude = double.Parse(columns[3]),
                        Longitude = double.Parse(columns[4])
                    })
                    .ToList();
            int i = 0;
            foreach (CsvRow row in CSV)
            {
                if (i == row.GroupId)
                {
                    Group g = new Group(row.GroupId);
                    groupsConstructor.Add(g);
                    i++;
                }
            }
            GROUPS = groupsConstructor;
        }

        /// <summary>
        /// Returns Group with matching Id within ListGroups.GROUPS if one exists.
        /// Otherwise returns null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Group FindGroup(int id)
        {
            foreach (Group g in GROUPS)
            {
                if (g.Id == id) return g;
            }
            return null;
        }
    }
}
