using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class MembersModel
    {   [Key]
        public string Id { get; set; }
        public ApplicationUser User { get; set; }

        public MembersModel()
        {

        }

        public MembersModel(ApplicationUser user)
        {
            User = user;
        }
    }

    public class AdministratorModel
    {
        [Key]
        public string Id { get; set; }
        public ApplicationUser User { get; set; }

        public AdministratorModel()
        {

        }

        public AdministratorModel(ApplicationUser user)
        {
            User = user;
        }
    }
}