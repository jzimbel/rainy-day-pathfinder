namespace CS4800ResearchProject.Objects
{
    public class Door
    {
        private readonly LatLng Location;
        public readonly int Id;
        public readonly int GroupId;
        public double Latitude { get { return Location.Latitude; } }
        public double Longitude { get { return Location.Latitude; } }

        public Door (LatLng location, int id, int groupId)
        {
            this.Location = location;
            this.Id = id;
            this.GroupId = groupId;
        }

        public Door(double latitude, double longitude, int id, int groupId)
            : this(new LatLng(latitude, longitude), id, groupId) {
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
