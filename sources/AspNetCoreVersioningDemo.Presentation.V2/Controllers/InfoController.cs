using Asp.Versioning;
using DustInTheWind.AspNetCoreVersioningDemo.Presentation.V2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.AspNetCoreVersioningDemo.Presentation.V2.Controllers;

[ApiController]
[ApiVersion("2.0")]
[Route("info")]
public class InfoController : ControllerBase
{
    [HttpGet("version")]
    public VersionDto GetVersion()
    {
        return new VersionDto
        {
            Version = "2.0.0",
            Date = new DateTime(2025, 07, 30, 0, 0, 0, DateTimeKind.Utc),
            Description = "This is version 2.0 of the API, which includes additional features and improvements."
        };
    }
}