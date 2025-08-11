using Asp.Versioning;
using DustInTheWind.AspNetVersioningDemo.Presentation.V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DustInTheWind.AspNetVersioningDemo.Presentation.V1.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("info")]
public class InfoController : ControllerBase
{
    [HttpGet("version")]
    public VersionDto GetVersion()
    {
        return new VersionDto
        {
            Version = "1.0.0",
            Date = new DateTime(2024, 10, 23, 0, 0, 0, DateTimeKind.Utc)
        };
    }
}