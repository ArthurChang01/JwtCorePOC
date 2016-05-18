using JwtCoreTest.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;

namespace JwtCoreTest.Models.Auth
{
    public static class AudiencesStore
    {
        private static ConcurrentDictionary<string, Audience> AudiencesList = new ConcurrentDictionary<string, Audience>();

        public static Audience Find(string userName, string Pwd)
        {
            Audience result = null;

            IEnumerable<Audience> ieAd = AudiencesList.Values;
            result = ieAd.FirstOrDefault(o => o.UserName.Equals(userName) && o.PasswordHash.Equals(Pwd));

            return result;
        }

        public static Audience FindByIdAsync(string Id)
        {
            Audience result = null;

            result = AudiencesList[Id];

            return result;
        }

        public static Audience FindByNameAsync(string name)
        {
            Audience result = null;

            IEnumerable<Audience> ieAd = AudiencesList.Values;
            result = ieAd.FirstOrDefault(o => o.UserName.Equals(name));

            return result;
        }

        public static IdentityResult CreateAsync(Audience ad,string password) {
            ad.Id = Guid.NewGuid().ToString("N");
            ad.PasswordHash = password;
            ad.EmailConfirmed = true;
            AudiencesList.TryAdd(ad.Id, ad);
           

            return IdentityResult.Success;
        }

        public static IdentityResult ChangePasswordAsync(string Id, string oldPassword, string newPassword)
        {
            IdentityResult result = null;

            List<string> lsErrors = new List<string>();

            Audience ad;
            bool blResult = AudiencesList.TryGetValue(Id,out ad);
            if (!blResult)
                lsErrors.Add("user doesn't exists!");

            if (ad.PasswordHash.Equals(oldPassword))
                lsErrors.Add("user password is not matched!");

            if (lsErrors.Count > 0)
                return new IdentityResult(lsErrors.ToArray());

            ad.PasswordHash = newPassword;

            return IdentityResult.Success;
        }

        public static IdentityResult DeleteAsync(Audience appUser)
        {
            AudiencesList.TryRemove(appUser.Id, out appUser);

            return IdentityResult.Success;
        }

    }
}