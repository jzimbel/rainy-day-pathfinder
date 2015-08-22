using System.Collections.Generic;

namespace CS4800ResearchProject.Objects
{
    public class Group
    {
        public List<Door> Doors;
        public readonly List<string> Buildings;
        public int Id;

        public Group(int id)
        {
            Doors = new List<Door>();
            this.Id = id;
            foreach (CsvRow row in ListGroups.CSV)
            {
                if (row.GroupId == id)
                {
                    Door d = new Door(row.Latitude, row.Longitude, row.DoorId, id);
                    Doors.Add(d);
                }
            }
        }

        public Edge ShortestEdge(Group g)
        {
            return ShortestEdge(this, g);
        }

        public static Edge ShortestEdge(Group groupA, Group groupB)
        {
            Edge e = null;
            foreach (Door doorA in groupA.Doors)
            {
                foreach (Door doorB in groupB.Doors)
                {
                    Edge tempE = new Edge(doorA, doorB);
                    if (e == null)
                    {
                        e = tempE;
                        continue;
                    }
                    if (e.Distance > tempE.Distance)
                    {
                        e = tempE;
                    }
                }
            }
            return e;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return (obj as Group).Id == this.Id;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
