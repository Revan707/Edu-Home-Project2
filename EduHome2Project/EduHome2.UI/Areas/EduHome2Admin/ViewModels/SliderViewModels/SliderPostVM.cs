using System.ComponentModel.DataAnnotations;

namespace EduHome2.UI.Areas.EduHome2Admin.ViewModels.SliderViewModels;

public class SliderPostVM
{
    [Required,MaxLength(255)]
    public string BackgroundImageUrl { get; set; } = null!;
    [Required, MaxLength(50)]
    public string Title { get; set; } = null!;
    [Required, MaxLength(50)]
    public string SmallTitle { get; set; } = null!;
    [Required, MaxLength(200)]
    public string Description { get; set; } = null!;
}
