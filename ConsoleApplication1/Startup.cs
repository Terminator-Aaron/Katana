using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(ConsoleApplication1.Startup))]

namespace ConsoleApplication1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions());

            string name = string.Empty;
            app.Run(context =>
            {
                if (context.Request.User == null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, "Brock"));
                    claims.Add(new Claim(ClaimTypes.Email, "brockallen@gmail.com"));
                    var id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

                    var authManager = context.Authentication;
                    authManager.SignIn(id);
                }
                else 
                {
                    name = context.Request.User.Identity.Name;   
                }

                context.Response.ContentType = "text/html";
                return context.Response.WriteAsync(string.Format("Hello {0} from custom host.", name));
            });
        }
    }
}
