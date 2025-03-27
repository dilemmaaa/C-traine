using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_trainee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Привет, мир!";
        }
    }
}
