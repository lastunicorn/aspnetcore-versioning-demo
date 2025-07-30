using Asp.Versioning;
using DustInTheWind.AspNetVersioningDemo.Presentation.V2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DustInTheWind.AspNetVersioningDemo.Presentation.V2.Controllers;

/// <summary>
/// Controller for providing API information and version details for version 2.0
/// </summary>
/// <remarks>
/// This controller handles requests related to API information including version details,
/// release information, and feature descriptions for the version 2.0 API.
/// </remarks>
[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/info")]
public class InfoController : ControllerBase
{
    /// <summary>
    /// Gets the API version information for version 2.0
    /// </summary>
    /// <remarks>
    /// Returns detailed information about the current API version including version number,
    /// release date, and description of features and improvements.
    /// </remarks>
    /// <returns>Version information including version number, date, and description</returns>
    /// <response code="200">Successfully retrieved version information</response>
    [HttpGet("version")]
    [ProducesResponseType(typeof(VersionDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public ActionResult<VersionDto> GetVersion()
    {
        return Ok(new VersionDto
        {
            Version = "2.0.0",
            Date = new DateTime(2025, 07, 30, 0, 0, 0, DateTimeKind.Utc),
            Description = "This is version 2.0 of the API, which includes additional features and improvements."
        });
    }
}