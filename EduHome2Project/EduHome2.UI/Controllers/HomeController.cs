using EduHome2.Core.Entities;
using EduHome2.DataAccess.Contexts;
using EduHome2.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome2.UI.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        HomeVM homeVM = new()
        {
            Sliders = await _context.Sliders.ToListAsync(),
            Notices = await _context.Notices.ToListAsync(),
            Courses = await _context.Courses.ToListAsync(),
            Testimonials = await _context.testimonials.ToListAsync(),
            CourseCatagories = await _context.CourseCatagories.ToListAsync(),
            Events = await _context.Events.ToListAsync(),
            Blogs = await _context.Blogs.ToListAsync(),
            Assesments = await _context.Assesments.ToListAsync(),
            CourseDetails = await _context.CourseDetails.ToListAsync(),
            Languages = await _context.Languages.ToListAsync(),
            SkillLevels = await _context.SkillLevels.ToListAsync(),
        };
        return View(homeVM);
    }
}
