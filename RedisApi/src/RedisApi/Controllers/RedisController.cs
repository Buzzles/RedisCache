using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RedisApi.Controllers
{
    [Route("[controller]")]
    public class RedisController : Controller
    {
        // GET api/redis/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/redis
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/redis/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/redis/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
