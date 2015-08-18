namespace CS4800ResearchProject.Objects
{
    /// <summary>
    /// Represents a row in the CSV file we read in for door locations/groupings
    /// </summary>
    public class CsvRow
    {
        public int DoorId;
        public string Building;
        public int GroupId;
        public double Latitude;
        public double Longitude;
    }
}
