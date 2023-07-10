using EduHome2.Core.Entities;
using HomeEdu.Core.Entities;

namespace EduHome2.UI.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; } = null!;
        public IEnumerable<Notice> Notices { get; set; } = null!;
        public IEnumerable<Course> Courses { get; set; } = null!;
        public IEnumerable<testimonial> Testimonials { get; set; } = null!;
        public IEnumerable<CourseCatagory> CourseCatagories { get; set; } = null!;
        public IEnumerable<Event> Events { get; set; } = null!;
        public IEnumerable<Blog> Blogs { get; set; } = null!;
        public IEnumerable<Assesment> Assesments { get; set; } = null!;
        public IEnumerable<CourseDetail> CourseDetails { get; set; } = null!;
        public IEnumerable<Language> Languages { get; set; } = null!;
        public IEnumerable<SkillLevel> SkillLevels { get; set; } = null!;
    }
}
