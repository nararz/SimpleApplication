using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Data.Infrastructure;
using Task.Model.Models;

namespace Task.Data.Repositories
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IGroupRepository : IRepository<Group>
    {
    }
}
