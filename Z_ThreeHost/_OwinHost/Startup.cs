using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(_OwinHost.Startup))]

namespace _OwinHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.Run(context =>
            {
                //context.Response.ContentType = "plain/html";
                return context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
