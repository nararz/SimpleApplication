using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        TaskEntities dbContext;

        public TaskEntities Init()
        {
            return dbContext ?? (dbContext = new TaskEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
