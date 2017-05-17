using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRI_NaszSamochód.Models
{
    public enum VehicleBody
    {
        SUV,
        Convertible,
        Coupe,
        Hatchback,
        Sedan,
        Wagon,
        Minivan,
        MPV,
        Luxury,
        Motorcycle
    }

    public class VehicleModel
    {
        [Key]
        [Required]
        public int Key { get; set; }

        public ApplicationUser Owner { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string YearBuilt { get; set; }
        public string YearBought { get; set; }
        public string Color { get; set; }
        public EngineModel Engine { get; set; }
        public VehicleBody VehicleBody { get; set; }

        public List<VehicleStatisticsModel> Statistics { get; set; }
    }
}