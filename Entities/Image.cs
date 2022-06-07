using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Image
{
    [Key]
    [Required,MaxLength(25)]
    public string Title { get; set; }
    [MaxLength(150)]
    public string Description { get; set; }
    [Required]
    public string Url { get; set; }
    [Required]
    public string Topic { get; set; }
}