using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class CommentModel
    {
        public ApplicationUser Creator { get; set; }
        public string Text { get; set; }
    }
}