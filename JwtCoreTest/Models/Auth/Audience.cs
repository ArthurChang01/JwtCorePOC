using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JwtCoreTest.Models.Auth
{
    public class Audience : IdentityUser
    {
        [Required]
        public DateTime JoinDate { get; set; }

        public bool Active { get; set; }

        public ClaimsIdentity GenerateUserIdentityAsync()
        {
            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, this.UserName));
            identity.AddClaim(new Claim("sub", this.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Manager"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Supervisor"));

            //var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return identity;
        }

    }
}