using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Task.Model.Models;

namespace Task.Data.Configuration
{
    class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            ToTable("Group");
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.Description).IsRequired().HasMaxLength(500);

        }
    }
}
