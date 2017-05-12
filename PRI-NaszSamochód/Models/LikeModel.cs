using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class LikeModel
    {   [Key]
        public int Id { get; set; }
        public virtual ApplicationUser Liker { get; set; }
    }
}