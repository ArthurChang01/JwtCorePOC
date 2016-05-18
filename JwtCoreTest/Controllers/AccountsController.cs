using JwtCoreTest.Models.Auth;
using JwtCoreTest.Models.Infrastructure;
using JwtCoreTest.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace JwtCoreTest.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userName">使用者帳戶</param>
        /// <param name="password">密碼</param>
        /// <returns>Token</returns>
        [ResponseType(typeof(HttpResponseMessage))]
        public async Task<HttpResponseMessage> GetLogin(string userName, string password) {
            var request = HttpContext.Current.Request;
            var tokenServiceUrl = request.Url.GetLeftPart(UriPartial.Authority) + request.ApplicationPath + "/oauth2/token";
            using (var client = new HttpClient())
            {
                var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password)
            };
                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                var tokenServiceResponse = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                var responseCode = tokenServiceResponse.StatusCode;
                var responseMsg = new HttpResponseMessage(responseCode)
                {
                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                };
                return responseMsg;
            }
        }

        /// <summary>
        /// 依Id取得使用者資訊
        /// </summary>
        /// <param name="Id">使用者Id</param>
        /// <returns>使用者資訊</returns>
        [Authorize]
        [Route("user/{id:guid}", Name = "GetUserById")]
        [ResponseType(typeof(UserReturnModel))]
        public IHttpActionResult GetUser(string Id)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = AudiencesStore.FindByIdAsync(Id);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        /// <summary>
        /// 依使用者名稱取得使用者資訊
        /// </summary>
        /// <param name="username">使用者名稱</param>
        /// <returns>使用者資訊</returns>
        [Authorize]
        [Route("user/{username}")]
        [ResponseType(typeof(Audience))]
        public IHttpActionResult GetUserByName(string username)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            var user = AudiencesStore.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();

        }

        /// <summary>
        /// 創建使用者
        /// </summary>
        /// <param name="createUserModel">帳戶基本資訊</param>
        /// <returns>是否創建成功</returns>
        [AllowAnonymous]
        [Route("create")]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult CreateUser(CreateUserBindingModel createUserModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Audience()
            {
                UserName = createUserModel.Username,
                Email = createUserModel.Email,
                JoinDate = DateTime.Now.Date,
            };

            IdentityResult addUserResult = null;

            try {
                addUserResult = AudiencesStore.CreateAsync(user, createUserModel.Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            return Created(locationHeader, TheModelFactory.Create(user));

        }

        /// <summary>
        /// 修改帳戶密碼
        /// </summary>
        /// <param name="model">密碼資訊(舊,新)</param>
        /// <returns></returns>
        [Authorize]
        [Route("ChangePassword")]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = AudiencesStore.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="id">欲刪除帳戶的Id</param>
        /// <returns>是否刪除成功</returns>
        [Authorize]
        [Route("user/{id:guid}")]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult DeleteUser(string id)
        {

            //Only SuperAdmin or Admin can delete users (Later when implement roles)

            var appUser = AudiencesStore.FindByIdAsync(id);

            if (appUser != null)
            {
                IdentityResult result = AudiencesStore.DeleteAsync(appUser);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();

            }

            return NotFound();

        }

    }
}
