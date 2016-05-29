using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Task.Model.Models;

namespace Task.Data
{
    public class TaskSeedData : DropCreateDatabaseIfModelChanges<TaskEntities>
    {
        protected override void Seed(TaskEntities context)
        {
            GetUsers().ForEach(u => context.Users.Add(u));
            GetGroups().ForEach(g => context.Groups.Add(g));
            GetStories().ForEach(s => context.Stories.Add(s));

            context.Commit();
        }

        private static List<User> GetUsers()
        {
            return new List<User>();
        }

        private static List<Group> GetGroups()
        {
            return new List<Group>();
        }

        private static List<Story> GetStories()
        {
            return new List<Story>();
        }
    }
}
