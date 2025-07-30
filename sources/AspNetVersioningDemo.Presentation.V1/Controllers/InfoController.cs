using Asp.Versioning;
using DustInTheWind.AspNetVersioningDemo.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.AspNetVersioningDemo.Presentation.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/info")]
public class InfoController : ControllerBase
{
    [HttpGet("version")]
    public ActionResult<VersionDto> GetVersion()
    {
        return Ok(new VersionDto
        {
            Version = "1.0.0",
            Date = new DateTime(2024, 10, 23, 0, 0, 0, DateTimeKind.Utc)
        });
    }
}