using Asp.Versioning;
using DustInTheWind.AspNetVersioningDemo.V2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.AspNetVersioningDemo.V2.Controllers;

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/info")]
public class InfoController : ControllerBase
{
    [HttpGet("version")]
    public ActionResult<string> GetVersion()
    {
        return Ok(new VersionDto
        {
            Version = "2.0.0",
            Date = new DateTime(2025, 07, 30, 0, 0, 0, DateTimeKind.Utc),
            Description = "This is version 2.0 of the API, which includes additional features and improvements."
        });
    }
}