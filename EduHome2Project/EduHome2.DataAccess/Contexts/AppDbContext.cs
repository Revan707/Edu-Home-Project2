
using EduHome2.Core.Entities;
using HomeEdu.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHome2.DataAccess.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Slider> Sliders { get; set; } = null!;
    public DbSet<Notice> Notices { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<testimonial> testimonials { get; set; } = null!;

    public DbSet<CourseCatagory> CourseCatagories { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<Assesment> Assesments { get; set; } = null!;
    public DbSet<CourseDetail> CourseDetails { get; set; } = null!;
    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<SkillLevel> SkillLevels { get; set; } = null!;
}
