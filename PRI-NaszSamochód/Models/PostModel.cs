using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRI_NaszSamochod;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRI_NaszSamochód.Models
{
    public class PostModel
    {   
        [Key]
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public int CreatorId { get; set; } 
        public ApplicationUser Creator { get; set; }
        public String Text { get; set; }
        
        public String PhotoPath { get; set; }
        public virtual ICollection<ApplicationUser> Likes { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }


    }
}