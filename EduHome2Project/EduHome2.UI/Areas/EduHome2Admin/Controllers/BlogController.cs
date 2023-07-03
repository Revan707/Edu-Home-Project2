using AutoMapper;
using EduHome2.Core.Entities;
using EduHome2.DataAccess.Contexts;
using EduHome2.UI.Areas.EduHome2Admin.ViewModels.BlogViewModels;
using EduHome2.UI.Areas.EduHome2Admin.ViewModels.SliderViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome2.UI.Areas.EduHome2Admin.Controllers;
[Area("EduHome2Admin")]

public class BlogController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BlogController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.Blogs.ToListAsync());
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(BlogPostVM blogPost)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        Blog blog = _mapper.Map<Blog>(blogPost);
        await _context.Blogs.AddAsync(blog);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int Id)
    {
        Blog? blogdb = await _context.Blogs.FindAsync(Id);
        if (blogdb == null)
        {
            return NotFound();
        }
        return View(blogdb);
    }
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int Id)
    {
        Blog? blogdb = await _context.Blogs.FindAsync(Id);
        if (blogdb == null)
        {
            return NotFound();
        }
        _context.Blogs.Remove(blogdb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int Id)
    {
        Blog? blogdb = await _context.Blogs.FindAsync(Id);
        if (blogdb == null)
        {
            return NotFound();
        }
        return View(blogdb);

    }
    [ActionName("Update")]
    [HttpPost]
    public async Task<IActionResult> Update(int Id, Blog blog)
    {
        if (Id == blog.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return View(blog);
        }
        Blog? blogdb = await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(s => s.Id == Id);
        if (blogdb == null)
        {
            return NotFound();
        }
        _context.Entry(blog).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }
}
