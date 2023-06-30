using EduHome2.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EduHome2.Core.Entities;

public class Slider : IEntity
{
    public int Id { get ; set ; }
    [Required, MaxLength(255)]
    public string BackgroundImageUrl { get; set; } = null!;
    [Required,MaxLength(50)]
    public string Title { get; set; }= null!;
    [Required, MaxLength(50)]
    public string SmallTitle { get; set; } = null!;
    [Required, MaxLength(200)]
    public string Description { get; set; } = null!;
}
