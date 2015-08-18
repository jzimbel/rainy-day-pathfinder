namespace CS4800ResearchProject.Objects
{
    public class Door
    {
        public readonly LatLng Location;
        public readonly int Id;
        public readonly int GroupId;

        public Door (LatLng location, int id, int groupId)
        {
            this.Location = location;
            this.Id = id;
            this.GroupId = groupId;
        }

        public double Distance (Door d)
        {
            return Distance(this, d);
        }

        public static double Distance (Door d1, Door d2)
        {
            return LatLng.Distance(d1.Location, d2.Location);
        }
    }
}
