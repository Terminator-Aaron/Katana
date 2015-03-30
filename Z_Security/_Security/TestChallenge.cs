using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.Cookies;

namespace _Security
{
    public class TestChallenge : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var authManager = context.GetOwinContext().Authentication;
            authManager.Challenge("CCC");

            var response = context.GetOwinContext().Response;
            response.StatusCode = 401;
            response.Write("UnAuorize");
        }
    }
}