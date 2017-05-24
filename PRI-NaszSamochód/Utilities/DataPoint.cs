using System;
using System.Runtime.Serialization;

namespace PRI_NaszSamochód.Utilities
{
    // Used in CanvasJS to make charts
    [DataContract]
    public class DataPoint
    {
        [DataMember(Name = "x")]
        public Nullable<DateTime> X = null;

        [DataMember(Name = "y")]
        public Nullable<double> Y = null;

        public DataPoint(DateTime x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}