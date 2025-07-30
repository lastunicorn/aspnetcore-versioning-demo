using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.AspNetVersioningDemo.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/info")]
public class InfoController : ControllerBase
{
    [HttpGet("version")]
    [MapToApiVersion("1.0")]
    public ActionResult<string> GetVersionV1()
    {
        return Ok("1.0.0");
    }

    [HttpGet("version")]
    [MapToApiVersion("2.0")]
    public ActionResult<string> GetVersionV2()
    {
        return Ok("2.0.0");
    }
}