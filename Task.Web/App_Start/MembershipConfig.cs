using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Data;
using WebMatrix.WebData;

namespace Task.Web
{
    public static class MembershipConfig
    {
        public static void InitializeMembership()
        {
            //TaskEntities context = new TaskEntities();
            //context.Database.Initialize(true);
            try
            {
                using (var context = new TaskEntities())
                {
                    if (!context.Database.Exists())
                    {
                        context.Database.Initialize(true);
                    }
                }
                if (!WebSecurity.Initialized)
                {
                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "User", "UserId", "UserName", autoCreateTables: true);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Database could not be initialized", ex);
            }
        }
    }
}