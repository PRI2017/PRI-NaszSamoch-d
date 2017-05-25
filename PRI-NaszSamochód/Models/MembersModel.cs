using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class MembersModel
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public ApplicationUser User { get; set; }

        public AdministratorModel()
        {

        }

        public AdministratorModel(ApplicationUser user)
        {
            Guid guid = new Guid();
            Id = guid.ToString();
            User = user;
        }
    }
}