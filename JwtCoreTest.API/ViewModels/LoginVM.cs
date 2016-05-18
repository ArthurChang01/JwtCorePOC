using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JwtCoreTest.API.ViewModels
{
    public class LoginVM
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}