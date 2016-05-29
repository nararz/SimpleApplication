using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Data.Infrastructure;
using Task.Model.Models;

namespace Task.Data.Repositories
{
    public class StoryRepository : RepositoryBase<Story>, IStoryRepository
    {
        public StoryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IStoryRepository : IRepository<Story>
    {
    }
}
