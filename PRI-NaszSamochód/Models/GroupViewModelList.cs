using Ninject.Infrastructure.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class GroupViewModelList
    {
        private readonly List<GroupModel> _groups;

        public GroupViewModelList(List<GroupModel> groups)
        {
            _groups = groups;
        }

        public List<GroupViewModel> GetGroupViewModels()
        {
            var GroupViewList = new List<GroupViewModel>();
            _groups.Map(model => GroupViewList.Add(new GroupViewModel(model)));
            return GroupViewList;
        }
        public List<GroupModel> GetGroupModels()
        {
            return _groups;
        }
    }
}