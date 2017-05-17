using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using PRI_NaszSamochód.Utilities;

namespace PRI_NaszSamochód.Models
{
    public class VehicleStatisticsModel
    {
        [Key]
        [Required]
        public int Key { get; set; }

        public double KilometersDriven { get; set; }
        public double FuelUsed { get; set; }
        public double MaxVelocity { get; set; }
        public DateTime RecordTime { get; set; }
    }

    public class RouteStatisticsModel
    {
        [Key]
        [Required]
        public int Key { get; set; }
        public Coordinates StartPoint { get; set; }
        public Coordinates EndPoint { get; set; }
        public double RouteLength { get; set; }
        public List<string> PlacesSeen { get; set; }
        public DateTime RouteStartTime { get; set; }
        public DateTime RouteEndTime { get; set; }
    }

    // Used in CanvasJS to make charts
    [DataContract]
    public class DataPoint
    {
        [DataMember(Name = "x")]
        public Nullable<double> X = null;

        [DataMember(Name = "y")]
        public Nullable<double> Y = null;

        public DataPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}