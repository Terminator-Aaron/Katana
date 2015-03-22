using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseUrl = "http://localhost:5000/";

            using (WebApp.Start<Startup>(new StartOptions { Urls = { baseUrl } }))
            {
                Console.WriteLine("Press Enter to quit.");
                Console.ReadKey();
            }
        }
    }

    public class LoggerMiddleware : OwinMiddleware
    {
        private readonly ILog _logger;

        public LoggerMiddleware(OwinMiddleware next, ILog logger)
            : base(next)
        {
            _logger = logger;
        }

        public override async Task Invoke(IOwinContext context)
        {
            _logger.LogInfo("Middleware begin");
            await this.Next.Invoke(context);
            _logger.LogInfo("Middleware end");
        }
    }

    public class Logger
    {
        public void LogInfo(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public interface ILog
    {
        void LogInfo(string msg);
    }
}
