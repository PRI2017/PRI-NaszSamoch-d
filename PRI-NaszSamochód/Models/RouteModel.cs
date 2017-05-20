using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class RouteModel
    {
        [Key]
        [Required]
        public int Key { get; set; }

        public ApplicationUser Owner { get; set; }

        public string Name { get; set; }
        public List<POI> PlacesSeen { get; set; }
        public RouteStatisticsModel Statistics { get; set; }
    }
}