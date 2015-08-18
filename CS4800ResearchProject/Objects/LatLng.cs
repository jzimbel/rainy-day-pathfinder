using System;

namespace CS4800ResearchProject.Objects
{
    public class LatLng
    {
        private readonly double m_lat;
        private readonly double m_lng;

        public double Latitude { get { return m_lat; } }
        public double Longitude { get { return m_lng; } }

        public LatLng(double latitude, double longitude)
        {
            m_lat = latitude;
            m_lng = longitude;
        }

        public double Distance(LatLng latlng)
        {
            return Distance(this, latlng);
        }

        public static double Distance(LatLng latlng_a, LatLng latlng_b)
        {
            return Distance(latlng_a.Latitude, latlng_a.Longitude, latlng_b.Latitude, latlng_b.Longitude);
        }

        private static double Distance(double lat_a, double lng_a, double lat_b, double lng_b)
        {
            double theta = lng_a - lng_b;
            double dist = Math.Sin(deg2rad(lat_a)) * Math.Sin(deg2rad(lat_b))
                        + Math.Cos(deg2rad(lat_a)) * Math.Cos(deg2rad(lat_b)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;
            return dist / 1000;
        }
            
        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
