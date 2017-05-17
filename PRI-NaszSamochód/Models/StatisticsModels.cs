using PRI_NaszSamochód.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public List<POI> PlacesSeen { get; set; }
        public DateTime RouteStartTime { get; set; }
        public DateTime RouteEndTime { get; set; }
    }
}