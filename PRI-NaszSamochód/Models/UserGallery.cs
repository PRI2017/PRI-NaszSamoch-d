using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;

namespace PRI_NaszSamochód.Models
{
    public class UserGalleryModel
    {
        public int Id { get; set; }
        public ApplicationUser Owner { get; set; }
        public string Name { get; set; }
        public virtual List<PhotoModel> PhotosList { get; set; }

        public UserGalleryModel() { }

        public UserGalleryModel(string name, ApplicationUser owner)
        {
            Name = name;
            Owner = owner;
        }
    }
}