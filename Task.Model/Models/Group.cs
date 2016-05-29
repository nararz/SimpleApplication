using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Model.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Group()
        {
            Stories = new HashSet<Story>();
            Users = new HashSet<User>();
        }
    }
}