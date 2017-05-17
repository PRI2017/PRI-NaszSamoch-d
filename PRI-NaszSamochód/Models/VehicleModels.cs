using System.ComponentModel.DataAnnotations;

namespace PRI_NaszSamochód.Models
{
    public enum CarBody
    {
        SUV,
        Convertible,
        Coupe,
        Hatchback,
        Sedan,
        Wagon,
        Minivan,
        MPV,
        Luxury
    }

    public class Vehicle
    {
        public ApplicationUser Owner { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string YearBuilt { get; set; }
        public string YearBought { get; set; }
        public string Color { get; set; }
        public EngineModel Engine { get; set; }
    }

    public class CarModel : Vehicle
    {
        [Key]
        [Required]
        public int Key { get; set; }

        public CarBody CarBody { get; set; }
        public VehicleStatisticsModel Statistics { get; set; }
    }

    public class MotorcycleModel : Vehicle
    {
        public VehicleStatisticsModel Statistics { get; set; }
    }
}