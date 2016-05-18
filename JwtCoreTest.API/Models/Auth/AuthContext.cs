using JwtCoreTest.Models.Auth;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JwtCoreTest.API.Models.Auth
{
    public class AuthContext:IdentityDbContext
    {
        public AuthContext() : base("AuthContext")
        {
        }

        public DbSet<Audience> Audiences { get; set; }

    }
}