using EduHome2.Core.Entities;

namespace EduHome2.UI.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; } = null!;
        public IEnumerable<Notice> Notices { get; set; } = null!;
        public IEnumerable<Course> Courses { get; set; } = null!;
        public IEnumerable<CourseCatagory> CourseCatagories { get; set; } = null!;
    }
}
