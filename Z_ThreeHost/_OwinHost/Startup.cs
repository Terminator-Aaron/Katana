using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IO;
using System.Security.Claims;
using Microsoft.Owin.Security.Cookies;
using System.Collections.Generic;
using System.Net.Http;

[assembly: OwinStartup(typeof(_OwinHost.Startup))]

namespace _OwinHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions() { AuthenticationType = "ExternalCookie" });

            app.Run(context =>
            {
                //context.Response.ContentType = "plain/html";

                var request = context.Request;
                var response = context.Response;

                // 跳转到登陆页面
                if (request.Method.ToLower() == "get")
                {
                    if (request.User != null && request.User.Identity.IsAuthenticated)
                    {
                        response.Write(string.Format("hell {0} <br/>", request.User.Identity.Name));
                    }
                    else
                    {
                        // 获取登陆信息
                        string htmlText = File.ReadAllText(@"D:\aaronzhang\MyLearn\katanaLearn\Z_Security\_Security\LoginPage.html");
                        response.ContentType = "text/html";
                        response.Write(htmlText);
                    }
                }

                // 提交登陆
                if (request.Method.ToLower() == "post")
                {
                    //try
                    //{
                    //    byte[] buffer = new byte[1024];
                    //    request.Body.Read(buffer, 0, buffer.Length);
                    //    string str = System.Text.UTF8Encoding.UTF8.GetString(buffer);
                    //}
                    //catch (Exception e)
                    //{ 

                    //}

                    //string query = request.QueryString.Value;
                    //string userName = query;
                    //string password = query;

                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, "Brock"));
                    claims.Add(new Claim(ClaimTypes.Email, "brockallen@gmail.com"));
                    var id = new ClaimsIdentity(claims, "ExternalCookie");

                    var authManager = context.Authentication;
                    authManager.SignIn(id);

                    response.ContentType = "text/html";
                    response.Write("Logon Successful");
                }



                return response.WriteAsync("Hello World!");
            });
        }
    }
}
