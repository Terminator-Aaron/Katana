using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        [Route("PublicResource")]
        [HttpGet]
        public IEnumerable<string> PublicResource()
        {
            return new string[] { "公开资源1", "公开资源2" };
        }

        // GET api/<controller>
        [Route("ProtectedResource")]
        [HttpGet]
        [Authorize]
        public IEnumerable<string> ProtectedResource()
        {
            return new string[] { "这是受保护资源1", "这是受保护资源2" };
        }

        // GET api/<controller>/5
        [Authorize]
        public string Get(int id)
        {
            return "这是受保护资源！";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}