using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

[assembly: OwinStartup(typeof(_Security.Startup))]

namespace _Security
{
    public class Startup
    {
        public static string PublicClientId { get; private set; }


        public void Configuration(IAppBuilder app)
        {
            PublicClientId = "self";
            OAuthAuthorizationServerOptions aAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                //AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            app.UseOAuthAuthorizationServer(aAuthOptions);

            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            //{
            //    AccessTokenFormat = aAuthOptions.AccessTokenFormat,
            //    AccessTokenProvider = aAuthOptions.AccessTokenProvider,
            //    AuthenticationMode = aAuthOptions.AuthenticationMode,
            //    AuthenticationType = aAuthOptions.AuthenticationType,
            //    Description = aAuthOptions.Description,
            //    Provider = new ApplicationOAuthBearerProvider(),
            //    SystemClock = aAuthOptions.SystemClock
            //});



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
