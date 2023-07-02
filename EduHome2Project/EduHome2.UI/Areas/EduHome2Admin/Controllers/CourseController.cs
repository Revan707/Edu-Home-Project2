using EduHome2.Core.Entities;
using EduHome2.DataAccess.Contexts;
using EduHome2.UI.Areas.EduHome2Admin.ViewModels.CourseViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome2.UI.Areas.EduHome2Admin.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        [Area("EduHome2Admin")]
        public async Task<IActionResult> Index()
        {
            List<Course> courses = await _context.Courses.ToListAsync();
            return View(courses);

        }

        [Area("EduHome2Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Catagories = await _context.CourseCatagories.ToListAsync();
            return View();
        }

        [Area("EduHome2Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoursePostVM coursePost, int CatagoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var catagory = _context.CourseCatagories.Find(CatagoryId);

            if (catagory is null)
            {
                return BadRequest();
            }

            Course course = new();
            course.Title = coursePost.Title;
            course.Description = coursePost.Description;
            course.ImagePath = coursePost.ImagePath;
            course.CourseCatagoryId = CatagoryId;
            await _context.AddAsync(course);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [Area("EduHome2Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        [Area("EduHome2Admin")]
        [HttpPost]
        [ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
