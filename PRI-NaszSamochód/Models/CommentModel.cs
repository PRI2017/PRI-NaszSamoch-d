using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser Creator { get; set; }
        public string Text { get; set; }
        public DateTime AddedTime { get; set; }
    }
}