using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace JwtCoreTest.Controllers
{
    public class TestController : ApiController
    {
        /// <summary>
        /// Tester
        /// </summary>
        /// <returns>字串</returns>
        public IHttpActionResult Tester()
        {
            var session = HttpContext.Current.Session;
            string str = string.Empty;

            if (session != null)
            {
                session["Timer"] = session["Timer"] != null ? session["Timer"].ToString() : DateTime.Now.ToString();
                str = session["Timer"].ToString();
            }

            return Ok(str);
        }
    }
}