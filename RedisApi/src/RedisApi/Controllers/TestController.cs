using Microsoft.AspNetCore.Mvc;

namespace RedisApi.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Test Controller for Redis Api. Booyakasha";
        }
    }
}
