using System.ComponentModel.DataAnnotations;

namespace EduHome2.UI.Areas.EduHome2Admin.ViewModels.CourseViewModels;

public class CoursePostVM
{
    [Required, MaxLength(10)]
    public string? Title { get; set; }
    [Required, MaxLength(120)]
    public string? Description { get; set; }
    [Required, MaxLength(255)]
    public string? ImagePath { get; set; }
}
