using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace JwtCoreTest.Models.Auth
{
    /// <summary>
    /// 受眾
    /// </summary>
    public class Audience : IdentityUser
    {
        [Required]
        public DateTime JoinDate { get; set; }

        public bool Active { get; set; }

        public ClaimsIdentity GenerateUserIdentityAsync()
        {
            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, this.Id));
            identity.AddClaim(new Claim(ClaimTypes.Name, this.UserName));
            identity.AddClaim(new Claim("sub", this.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

            return identity;
        }

    }
}