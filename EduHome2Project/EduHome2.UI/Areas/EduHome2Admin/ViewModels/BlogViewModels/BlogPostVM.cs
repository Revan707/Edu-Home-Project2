using System.ComponentModel.DataAnnotations;

namespace EduHome2.UI.Areas.EduHome2Admin.ViewModels.BlogViewModels;

public class BlogPostVM
{
    [Required, MaxLength(255)]
    public string ImagePath { get; set; } = null!;
    [Required, MaxLength(50)]
    public string Name { get; set; } = null!;
    public DateTime Date { get; set; } 
    public int MessageBox { get; set; } 
    [Required, MaxLength(200)]
    public string Description { get; set; } = null!;
}
