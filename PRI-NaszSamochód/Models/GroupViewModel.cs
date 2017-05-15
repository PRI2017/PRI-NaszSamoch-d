using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class GroupViewModel
    {
        public GroupModel groupModel;

        public List<PostViewModel> LatestPosts { get; set; }

        public GroupViewModel(GroupModel groupModel)
        {
            this.groupModel = groupModel;
            using (var db = new ApplicationDbContext())
            {

            }
        }
    }
}