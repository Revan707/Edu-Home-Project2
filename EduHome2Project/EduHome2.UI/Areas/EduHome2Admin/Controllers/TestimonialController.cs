using AutoMapper;
using EduHome2.DataAccess.Contexts;
using HomeEdu.Core.Entities;
using HomeEdu.UI.Areas.Admin.ViewModels.TestimoniaViewModel;
using HomeEdu.UI.Helpers.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeEdu.UI.Areas.Admin.Controllers;
[Area("EduHome2Admin")]

public class TestimonialController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public TestimonialController(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
    {
        _context = context;
        _mapper = mapper;
        _env = env;
    }
    public async Task<IActionResult> Index()
    {

        List<testimonial> testimonials = await _context.testimonials.ToListAsync();
        return View(testimonials);
    }
    public async Task<IActionResult> Create()
    {
        ViewBag.Catagories = await _context.testimonials.ToListAsync();
        return View();
    }
    [HttpPost]
    [ActionName("Create")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create(testimonial testimonial)

    {
        if (!ModelState.IsValid)
        {
            return View(testimonial);
        }
        var testimonialdb = new testimonial
        {
            ImagePath = testimonial.ImagePath,
            Surname = testimonial.Surname,
            Name = testimonial.Name,
            Position = testimonial.Position,
            Description = testimonial.Description
        };
        await _context.testimonials.AddAsync(testimonialdb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }
    public async Task<IActionResult> Delete(int id)
    {
        var testimonial = await _context.testimonials.FindAsync(id);
        if (testimonial == null)
        {
            return NotFound();
        }
        return View(testimonial);
    }
    [HttpPost]
    [ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
        var testimonials = await _context.testimonials.FindAsync(id);
        if (testimonials == null)
        {
            return NotFound();
        }
        _context.testimonials.Remove(testimonials);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var testimonials = await _context.testimonials.FindAsync(id);
        if (testimonials == null)
        {
            return NotFound();
        }

        var testimoniaVM = new TestimoniaVM
        {
            Name = testimonials.Name,
            Surname = testimonials.Surname,
            Position = testimonials.Position,
            Description = testimonials.Description
    };

        return View(testimoniaVM);
    }
    [ActionName("Update")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, TestimoniaVM testimoniaVM)
    {
        if (id != testimoniaVM.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(testimoniaVM);
        }

        testimonial Testimonials = await _context.testimonials.FindAsync(id);
        if (Testimonials == null)
        {
            return BadRequest();
        }
        Testimonials.Name = testimoniaVM.Name;
        Testimonials.Surname = testimoniaVM.Surname;
        Testimonials.Position = testimoniaVM.Position;
        Testimonials.ImagePath = testimoniaVM.ImagePath;
        Testimonials.Description = testimoniaVM.Description;
        _context.Entry(Testimonials).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
