using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task.Web.Models
{
    public class GroupModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        public string Description { get; set; }

        public int StoriesCount { get; set; }

        public List<int> UserIds { get; set; }

        public GroupModel()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            StoriesCount = 0;
            UserIds = new List<int>();
        }
    }
}