using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class FriendsView
    {
      public FriendsView(List<FriendModel> friends)
        {
            this.Friends = friends;
        }

        public List<FriendModel> Friends;
    }

    public class FriendRequestView
    {
        
    }
}