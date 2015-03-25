using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Claims;
using Microsoft.Owin.Security.Cookies;

namespace _Security
{
    public class LoginHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var ctx = context.GetOwinContext();
            var request = ctx.Request;
            var response = ctx.Response;

            // 跳转到登陆页面
            if (request.Method.ToLower() == "get")
            {
                // 获取登陆信息
                string htmlText = File.ReadAllText(@"D:\aaronzhang\MyLearn\katanaLearn\Z_Security\_Security\LoginPage.html");
                response.ContentType = "text/html";
                response.Write(htmlText);
            }

            // 提交登陆
            if (request.Method.ToLower() == "post")
            {
                string userName = context.Request.Params["userName"];
                string password = context.Request.Params["password"];

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, "Brock"));
                claims.Add(new Claim(ClaimTypes.Email, "brockallen@gmail.com"));
                var id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

                var authManager = ctx.Authentication;
                authManager.SignIn(id);

                response.ContentType = "text/html";
                response.Write("Logon Successful");
            }

        }
    }
}