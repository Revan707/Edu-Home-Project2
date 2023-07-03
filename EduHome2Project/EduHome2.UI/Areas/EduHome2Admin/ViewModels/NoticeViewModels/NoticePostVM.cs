using System.ComponentModel.DataAnnotations;

namespace EduHome2.UI.Areas.EduHome2Admin.ViewModels.NoticeViewModels;

public class NoticePostVM
{
    public DateTime Date { get; set; }
    [Required, MaxLength(170)]
    public string Description { get; set; } = null!;
}
