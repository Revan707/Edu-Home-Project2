using AutoMapper;
using EduHome2.Core.Entities;
using EduHome2.DataAccess.Contexts;
using EduHome2.UI.Areas.EduHome2Admin.ViewModels.SliderViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome2.UI.Areas.EduHome2Admin.Controllers;
[Area("EduHome2Admin")]

public class SliderController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public SliderController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async  Task<IActionResult> Index()
    {
        return View(await _context.Sliders.ToListAsync());
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(SliderPostVM sliderPost)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        Slider slider = _mapper.Map<Slider>(sliderPost);
        await _context.Sliders.AddAsync(slider);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int Id)
    {
        Slider? sliderdb = await _context.Sliders.FindAsync(Id);
        if (sliderdb == null)
        {
            return NotFound();
        }
        return View(sliderdb);
    }
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int Id)
    {
        Slider? sliderdb = await _context.Sliders.FindAsync(Id);
        if (sliderdb == null)
        {
            return NotFound();
        }
        _context.Sliders.Remove(sliderdb);
        await _context.SaveChangesAsync();
        return  RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int Id)
    {
        Slider? sliderdb = await _context.Sliders.FindAsync(Id);
        if (sliderdb == null)
        {
            return NotFound();
        }
        return View(sliderdb);

    }
    [ActionName("Update")]
    [HttpPost]
    public async Task<IActionResult> Update(int Id,Slider slider)
    {
        if(Id==slider.Id)
        {
            return BadRequest();
        }
        if(!ModelState.IsValid)
        {
            return View(slider);
        }
        Slider? sliderDb = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(s=>s.Id==Id);
        if(sliderDb == null)
        {
            return NotFound();
        }
        _context.Entry(slider).State=EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }

}
