using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Task.Web.Models;

namespace Task.Web.Models
{
    public class StoryDetailsModel
    {
         public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public UserModel User { get; set; }

        public List<GroupModel> Groups { get; set; }

        public StoryDetailsModel()
        {
            PostedOn = default(DateTime);
            Groups = new List<GroupModel>();
        }
    }
}