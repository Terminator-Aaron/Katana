using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Security.Claims;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(_Security.Startup))]

namespace _Security
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            var cookieOptions = new CookieAuthenticationOptions()
            {
                LoginPath = new PathString("/LoginHandler"),
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                Provider = new AppCookieAuthProvider()
            };
            app.UseCookieAuthentication(cookieOptions);

            // web api
            var apiConfig = new System.Web.Http.HttpConfiguration();
            //apiConfig.MapHttpAttributeRoutes();
            //apiConfig.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            apiConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            app.UseWebApi(apiConfig);

            //app.Run(context =>
            //{
            //    context.Response.ContentType = "plain/html";
            //    return context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
