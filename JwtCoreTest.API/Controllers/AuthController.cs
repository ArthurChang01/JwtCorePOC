using JwtCoreTest.API.Models.Auth;
using JwtCoreTest.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity;
using JwtCoreTest.API.ViewModels;

namespace JwtCoreTest.API.Controllers
{
    public class AuthController : ApiController
    {
        private AuthContext _ctx = new AuthContext();

        [Route("login")]
        [ResponseType(typeof(Audience))]
        [HttpPost]
        public async Task<IHttpActionResult> Login(LoginVM vm)
        {
            Audience ad = null;

            ad = await _ctx.Audiences.FirstOrDefaultAsync(o => o.UserName.Equals(vm.UserName) && o.PasswordHash.Equals(vm.Password));

            if (ad == null)
                return NotFound();

            return Ok(ad);
        }

        [Route("user/{id:guid}", Name = "GetUserById")]
        [ResponseType(typeof(Audience))]
        public async Task<IHttpActionResult> GetUser([FromUri]string Id)
        {
            Audience ad = null;

            try {
                ad = await _ctx.Audiences.FindAsync(Id);
            }
            catch (Exception ex)
            {
                ex = ex.InnerException ?? ex;
                return InternalServerError(ex);
            }

            if (ad == null) return NotFound();

            return Ok(ad);
        }

        [Route("user/{username}")]
        [ResponseType(typeof(Audience))]
        public async Task<IHttpActionResult> GetUserByName([FromUri]string username)
        {
            Audience ad = null;

            try
            {
                ad = await _ctx.Audiences.FirstOrDefaultAsync(o => o.UserName.Equals(username));
            }
            catch (Exception ex)
            {
                ex = ex.InnerException ?? ex;
                return InternalServerError(ex);
            }

            if (ad == null) return NotFound();

            return Ok(ad);
        }

        [Route("user")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> PostUser(Audience createUserModel)
        {
            try {
                _ctx.Audiences.Add(createUserModel);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex = ex.InnerException ?? ex;
                return InternalServerError(ex);
            }

            return Ok(createUserModel.Id);
        }

        [Route("user/{id:guid}")]
        [ResponseType(typeof(bool))]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser([FromUri]string id, string newPwd)
        {
            bool blResult = true;

            Audience ad = new Audience() { Id = id };
            ad.PasswordHash = newPwd;

            try
            {
                this._ctx.Entry<Audience>(ad).State = EntityState.Modified;
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex = ex.InnerException ?? ex;
                return InternalServerError(ex);
            }

            return Ok(blResult);
        }

        [Route("user/{id:guid}")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> DeleteUser([FromUri]string id)
        {
            bool blResult = true;

            Audience ad = await _ctx.Audiences.FindAsync(id);

            if (ad == null)
                return BadRequest();

            try
            {
                this._ctx.Entry<Audience>(ad).State = EntityState.Deleted;
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex = ex.InnerException ?? ex;
                return InternalServerError(ex);
            }

            return Ok(blResult);
        }
    }
}
