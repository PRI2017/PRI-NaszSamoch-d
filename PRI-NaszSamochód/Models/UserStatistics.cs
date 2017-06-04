using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRI_NaszSamochód.Models
{
    public class UserStatistics
    {
        [Key]
        [Required]
        public int Key { get; set; }
        public ApplicationUser User { get; set; }
        public double KilometersDriven { get; set; }
        public double FuelUsed { get; set; }
        public double MaxVelocity { get; set; }
        public DateTime RecordTime { get; set; }
    }
}