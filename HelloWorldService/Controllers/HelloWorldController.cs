using Microsoft.AspNetCore.Mvc;

namespace HelloWorldService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController:ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello World";
        }
    }
}
