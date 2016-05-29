using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Task.Model.Models;

namespace Task.Data.Configuration
{
    class StoryConfiguration : EntityTypeConfiguration<Story>
    {
        public StoryConfiguration()
        {
            ToTable("Story");
            Property(s => s.Title).IsRequired().HasMaxLength(50);
            Property(s => s.Content).IsRequired().HasMaxLength(5000);
            Property(s => s.Description).IsRequired().HasMaxLength(500);
            Property(s => s.PostedOn).IsRequired();
        }
    }
}
