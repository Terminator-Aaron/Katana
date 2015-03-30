using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _Security
{
    //[RoutePrefix("api/Values")]
    //[AllowAnonymous]
    [HostAuthentication("Cookies")]
    //[Authorize]
    public class ABCController : ApiController
    {
        [Authorize]
        public string Get(int id)
        {
            return "这是受保护资源！";
        }

        // GET api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "公开资源1", "公开资源2" };
        //}


        //// GET api/<controller>
        //[Route("ProtectedResource")]
        //[HttpGet]
        //[Authorize]
        //public IEnumerable<string> ProtectedResource()
        //{
        //    return new string[] { "这是受保护资源1", "这是受保护资源2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "这是受保护资源！";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}