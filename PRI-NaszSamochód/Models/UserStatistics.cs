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

        [Display(Name ="Przejechane Kilometry")]
        public double KilometersDriven { get; set; }

        [Display(Name = "Zużyte paliwo")]
        public double FuelUsed { get; set; }

        [Display(Name = "Prędkość maksymalna")]
        public double MaxVelocity { get; set; }

        public DateTime RecordTime { get; set; }
    }
}