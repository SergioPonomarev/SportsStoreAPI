using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportsStoreAPI.Infrastructure.Identity
{
    public class StoreIdentityDbContext : IdentityDbContext<StoreUser>
    {
        public StoreIdentityDbContext() : base("SportsStoreAPIIdentityDb")
        {
            Database.SetInitializer<StoreIdentityDbContext>(new StoreIdentityDbInitializer());
        }

        public static StoreIdentityDbContext Create()
        {
            return new StoreIdentityDbContext();
        }
    }
}