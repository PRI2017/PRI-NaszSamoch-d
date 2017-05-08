using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class GroupModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string GroupName { get; set; }

        public string Description { get; set; }

        [Required]
        public string GroupTheme { get; set; }

        public virtual ICollection<PostModel> Posts { get; set; }

        public virtual ICollection<ApplicationUser> Administrators { get; set; }

        public virtual ICollection<ApplicationUser> Memebers { get; set; }
    }
}