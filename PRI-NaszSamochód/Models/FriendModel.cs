using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PRI_NaszSamochód.Models
{
    public enum FriendStatus
    {
        Friends, // Users are friends
        Requested, // User1 invited User2
        Pending // User1 was invited by User2

    }

    public class FriendModel
    {   [Key]
        public int User1Id { get; set; }
        public virtual ApplicationUser User1 { get; set; }
        public int User2Id { get; set; }
        public virtual ApplicationUser User2 { get; set; }
        public FriendStatus Status { get; set; }
    }
}