using PRI_NaszSamochód.Utilities;
using System.ComponentModel.DataAnnotations;

namespace PRI_NaszSamochód.Models
{
    public class POI
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}