using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class MembersModel : ApplicationUser
    {   //[Key]
        //public int Id { get; set; }
        //public ApplicationUser Member { get; set; }
        public bool IsAdmin { get; set; }
    }
}