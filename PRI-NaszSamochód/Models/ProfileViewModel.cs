using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class ProfileViewModel
    {
        public ProfileViewModel(ApplicationUser user)
        {
            User = user;
            ProfilePhotoUrl = "/ProfPhoto?userId=" + user.Id;
            BackPhotoUrl = "/BackPhoto?userId=" + user.Id;
        }


        public ApplicationUser User { get; set; }
        public String ProfilePhotoUrl { get; set; }
        public String BackPhotoUrl { get; set; }
        
    }
}