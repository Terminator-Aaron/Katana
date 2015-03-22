using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ConsoleApplication1.Startup))]

namespace ConsoleApplication1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888


            app.Run(context =>
            {
                context.Response.ContentType = "text/html";
                return context.Response.WriteAsync("Hello world from custom host.");
            });
        }
    }
}
