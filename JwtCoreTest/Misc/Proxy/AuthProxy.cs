using JwtCoreTest.Models.Auth;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace JwtCoreTest.Misc.Proxy
{
    public class AuthProxy
    {
        private RestClient client = new RestClient(ConfigurationManager.AppSettings["ac:APIUrl"]);
        private string resourceUrl = string.Empty;

        public async Task<Audience> Login(string userName, string password) {
            Audience ad = null;

            this.resourceUrl = "login";
            RestRequest request = new RestRequest(resourceUrl, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new {
                userName = userName,
                password = password
            });

            ad = (await client.ExecutePostTaskAsync<Audience>(request)).Data;

            return ad;
        }

        public async Task<Audience> GetUser(string Id) {
            Audience ad = null;

            this.resourceUrl = string.Format("user/{0}",Id);
            RestRequest request = new RestRequest(resourceUrl, Method.GET);
            request.RequestFormat = DataFormat.Json;

            ad = (await client.ExecuteGetTaskAsync<Audience>(request)).Data;

            return ad;
        }

        public async Task<Audience> GetUserByName(string username)
        {
            Audience ad = null;

            this.resourceUrl = string.Format("user/{0}", username);
            RestRequest request = new RestRequest(resourceUrl, Method.GET);
            request.RequestFormat = DataFormat.Json;

            ad = (await client.ExecuteGetTaskAsync<Audience>(request)).Data;

            return ad;
        }

        public async Task<string> Register(Audience ad)
        {
            string Id = string.Empty;

            this.resourceUrl = "user";
            RestRequest request = new RestRequest(resourceUrl, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(ad);

            Id = (await client.ExecutePostTaskAsync<string>(request)).Data;

            return Id;
        }

        public async Task<bool> ChangePassword(string id, string newPassword)
        {
            bool blResult = true;

            this.resourceUrl = string.Format("user/{0}",id);
            RestRequest request = new RestRequest(resourceUrl, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new {
                newPwd = newPassword
            });

            blResult = (await client.ExecutePostTaskAsync<bool>(request)).Data;

            return blResult;
        }

        public async Task<bool> DeleteUser(string id)
        {
            bool blResult = true;

            this.resourceUrl = string.Format("user/{0}",id);
            RestRequest request = new RestRequest(resourceUrl, Method.DELETE);
            request.RequestFormat = DataFormat.Json;

            blResult = (await client.ExecutePostTaskAsync<bool>(request)).Data;

            return blResult;
        }
    }
}