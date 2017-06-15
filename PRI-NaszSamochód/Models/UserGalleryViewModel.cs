using System.Collections.Generic;

namespace PRI_NaszSamochód.Models
{
    public class UserGalleryViewModel
    {
        private readonly List<UserGalleryModel> _userGalleries;
        
        public UserGalleryViewModel(List<UserGalleryModel> userGalleries)
        {
            _userGalleries = userGalleries;
        }

        public List<UserGalleryModel> Get()
        {
            return this._userGalleries;
        }
    }
}