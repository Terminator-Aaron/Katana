using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

//[assembly: OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public class Startup
    {
        public static string PublicClientId { get; private set; }



        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            // Enable the application to use bearer tokens to authenticate users
            PublicClientId = "self";
            OAuthAuthorizationServerOptions aAuthOptions = new OAuthAuthorizationServerOptions
                   {
                       TokenEndpointPath = new PathString("/Token"),
                       Provider = new ApplicationOAuthProvider(PublicClientId),
                       //AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                       AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                       AllowInsecureHttp = true
                   };
            app.UseOAuthBearerTokens(aAuthOptions);


            var apiConfig = new System.Web.Http.HttpConfiguration();
            apiConfig.SuppressDefaultHostAuthentication();
            apiConfig.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            apiConfig.MapHttpAttributeRoutes();
            apiConfig.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(apiConfig);

            //app.Run(context =>
            //{
            //    //context.Response.ContentType = "plain/html";
            //    return context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
                                     