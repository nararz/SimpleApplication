using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Data.Infrastructure;
using Task.Model.Models;

namespace Task.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IUserRepository : IRepository<User>
    {
    }
}
