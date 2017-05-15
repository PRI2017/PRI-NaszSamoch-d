using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Infrastructure.Language;

namespace PRI_NaszSamochód.Models
{
    public class PostViewModelList
    {
       private readonly List<PostModel> _posts ;

        public PostViewModelList(List<PostModel> posts)
        {
            this._posts = posts;
        }

        public List<PostViewModel> GetPostViewModels()
        {
            var ListPostView = new List<PostViewModel>();
            _posts.Map(model => ListPostView.Add(new PostViewModel(model)));
            return ListPostView;
        }


    }
}