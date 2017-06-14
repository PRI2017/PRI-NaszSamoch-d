using System.Collections.Generic;

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