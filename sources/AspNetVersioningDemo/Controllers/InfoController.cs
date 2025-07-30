using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.AspNetVersioningDemo.Controllers;

[ApiController]
[Route("info")]
public class InfoController : ControllerBase
{
    [HttpGet("version")]
    public ActionResult<string> GetVersion()
    {
        return Ok("1.0.0");
    }
}