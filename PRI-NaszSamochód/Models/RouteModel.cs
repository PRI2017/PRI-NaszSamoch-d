using PRI_NaszSamochód.Utilities;
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
        public Coordinates StartPoint { get; set; }
        public Coordinates EndPoint { get; set; }
        public List<POI> PlacesSeen { get; set; }
        public virtual List<RouteStatisticsModel> Statistics { get; set; }
    }
}