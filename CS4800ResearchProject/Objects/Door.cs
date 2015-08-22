namespace CS4800ResearchProject.Objects
{
    public class Door
    {
        private readonly LatLng m_location;
        public readonly int Id;
        public readonly int GroupId;
        public double Latitude { get { return m_location.Latitude; } }
        public double Longitude { get { return m_location.Latitude; } }

        public Door (LatLng location, int id, int groupId)
        {
            this.m_location = location;
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
            return LatLng.Distance(d1.m_location, d2.m_location);
        }
    }
}
