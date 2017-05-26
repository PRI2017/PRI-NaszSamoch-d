using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Infrastructure.Language;

namespace PRI_NaszSamochód.Models
{
    public class GroupViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Theme { get; set; }
        public AdministratorModel Admin { get; set; }
        public List<MembersModel> Members { get; set; }
        public List<PostViewModel> LatestPosts { get; set; }

        public GroupViewModel(GroupModel group)
        {
            LatestPosts = new List<PostViewModel>();
            Name = group.GroupName;
            Description = group.Description;
            Theme = group.GroupTheme;
            Admin = group.Administrator;
            Members = group.Members;
            foreach (var i in group.Posts.OrderByDescending(x=>x.Added).Take(20))
            {
                LatestPosts.Add(new PostViewModel(i));
            }
        }
    }

    public class PostViewModel
    {
        public ApplicationUser Creator { get; set; }
        public String CreatorPhoto { get; set; }
        public string Text { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public List<LikeModel> Likes { get; set; }

        public PostViewModel(PostModel post)
        {
            Creator = post.Creator;
            Text = post.Text;
            post.Comments.Map
                (comment => Comments.Add(new CommentViewModel(comment)));
            Likes = post.Likes.ToList();
            CreatorPhoto = "/ProfPhoto?userId=" + Creator.Id;
        }
    }

    public class CommentViewModel
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Added { get; set; }

        public CommentViewModel(CommentModel comment)
        {
            this.Text = comment.Text;
            this.Author = comment.Creator.Name;
            this.Added = comment.AddedTime;
        }
    }
}