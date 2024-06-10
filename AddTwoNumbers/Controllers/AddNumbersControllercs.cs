using Microsoft.AspNetCore.Mvc;

namespace AddTwoNumbers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddNumbersControllercs : ControllerBase
    {
        [HttpGet]
        public ActionResult<int> Get(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
