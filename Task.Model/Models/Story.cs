using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Model.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        public User User { get; set; }
        public virtual ICollection<Group> Groups { get; set; }

        public Story()
        {
            Groups = new HashSet<Group>();
        }
    }
}
