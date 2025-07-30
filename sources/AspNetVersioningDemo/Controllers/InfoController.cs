using Microsoft.AspNetCore.Mvc;

namespace AspNetVersioningDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        [HttpGet("version")]
        public ActionResult<string> GetVersion()
        {
            return Ok("1.0.0");
        }
    }
}