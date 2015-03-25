using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace _Security
{
    //[RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        //[Route("Login/{userName:string}/{password:string}")]
        [HttpGet]
        public void Login(string userName, string password)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "Brock"));
            claims.Add(new Claim(ClaimTypes.Email, "brockallen@gmail.com"));
            var id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

            //var ctx = Request.();
            //var authenticationManager = ctx.Authentication;
            //authenticationManager.SignIn(id);

        }
    }
}