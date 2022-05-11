using System.ComponentModel.DataAnnotations;

namespace BlazorWebClient.Data;

public class ProjectForm
{
    [Required]
    public string? Folder { get; set; }

    [Required]
    public string? Namespace { get; set; }

    [Required]
    public string? ProjectName { get; set; }

    [Required]
    public string? SslPort { get; set; }

    [Required]
    public string? GitName { get; set; }

    [Required]
    public string? GitEmail { get; set; }
}
