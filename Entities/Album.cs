using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Album
{
    [Key]
    [MaxLength(25)]
    public string Title { get; set; }
    [MaxLength(150)]
    public string Description { get; set; }
    [Required]
    public string CreatedBy { get; set; }
    public List<Image> Images { get; set; } = new List<Image>();
}