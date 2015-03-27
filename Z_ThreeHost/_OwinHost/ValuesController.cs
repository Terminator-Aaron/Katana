using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _OwinHost
{
    public class ABCController : ApiController
    {
        [Authorize]
        public string Get(int id)
        {
            return "这是受保护资源！";
        }
    }
}