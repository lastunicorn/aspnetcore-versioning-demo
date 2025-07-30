using System.ComponentModel.DataAnnotations;

namespace DustInTheWind.AspNetVersioningDemo.Presentation.V2.Models;

/// <summary>
/// Represents version information for the API
/// </summary>
public class VersionDto
{
    /// <summary>
    /// The semantic version number of the API
    /// </summary>
    /// <example>2.0.0</example>
    [Required]
    public string Version { get; set; }

    /// <summary>
    /// The release date of this API version
    /// </summary>
    /// <example>2025-07-30T00:00:00Z</example>
    [Required]
    public DateTime Date { get; set; }
    
    /// <summary>
    /// A description of the features and improvements in this version
    /// </summary>
    /// <example>This is version 2.0 of the API, which includes additional features and improvements.</example>
    public string Description { get; set; }
}