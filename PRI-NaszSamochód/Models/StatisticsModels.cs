using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class StatisticsModel
    {
        [Key]
        [Required]
        public int Key { get; set; }

        public double KilometersDriven { get; set; }
        public double FuelUsed { get; set; }
        public DateTime RecordStartTime { get; set; }
        public DateTime RecordEndTime { get; set; }
    }

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