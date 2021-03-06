﻿namespace PRI_NaszSamochód.Utilities
{
    public struct Coordinates
    {
        private readonly double latitude;
        private readonly double longitude;

        public double Latitude
        {
            get { return latitude; }
        }

        public double Longitude
        {
            get { return longitude; }
        }

        public Coordinates(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", Latitude, Longitude);
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinates && Equals((Coordinates)obj);
        }

        public bool Equals(Coordinates coord)
        {
            return Latitude == coord.Latitude && Longitude == coord.Longitude;
        }

        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }
    }
}