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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string GroupName { get; set; }

        public string Description { get; set; }

        [Required]
        public string GroupTheme { get; set; }

        public virtual AdministratorModel Administrator { get; set; }

        public virtual List<MembersModel> Members { get; set; }

        public virtual List<PostModel> Posts { get; set; }
    }
}