
using EduHome2.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduHome2.DataAccess.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Course> Courses { get; set; }
}
