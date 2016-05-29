using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Web.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<StoryModel> Stories { get; set; }
        public ICollection<GroupModel> Groups { get; set; }

        public UserModel()
        {
            Stories = new List<StoryModel>();
            Groups = new List<GroupModel>();
        }
    }
}