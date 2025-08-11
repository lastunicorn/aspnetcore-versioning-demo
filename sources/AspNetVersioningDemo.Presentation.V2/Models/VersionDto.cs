using System.ComponentModel.DataAnnotations;

namespace DustInTheWind.AspNetVersioningDemo.Presentation.V2.Models;

public class VersionDto
{
    [Required]
    public string Version { get; set; }

    [Required]
    public DateTime Date { get; set; }
    
    public string Description { get; set; }
}