using Microsoft.AspNetCore.Mvc; 

namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {

        //health-check
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
