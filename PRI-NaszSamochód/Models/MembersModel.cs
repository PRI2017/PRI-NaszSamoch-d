using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class MembersModel
    {
        public ApplicationUser Member { get; set; }
    }

    public class AdministratorsModel : MembersModel
    {
        
    }
}