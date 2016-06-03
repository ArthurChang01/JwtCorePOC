using JwtCoreTest.Models.Auth;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JwtCoreTest.API.Models.Auth
{
    public class AuthContext: IdentityDbContext<Audience>
    {
        public AuthContext() : base("AuthContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
            modelBuilder.Entity<Audience>()
                .ToTable("Users");
        }
    }
}