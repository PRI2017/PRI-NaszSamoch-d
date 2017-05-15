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
        [Required]
        public virtual ApplicationUser Creator { get; set; }
        public String Text { get; set; }
        public DateTime Added { get; set; }
        public String PhotoPath { get; set; }
        public virtual IList<LikeModel> Likes { get; set; }
        public virtual IList<CommentModel> Comments { get; set; }


    }

   
}