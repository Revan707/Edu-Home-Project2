using AutoMapper;
using EduHome2.Core.Entities;
using EduHome2.DataAccess.Contexts;
using EduHome2.UI.Areas.EduHome2Admin.ViewModels.NoticeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome2.UI.Areas.EduHome2Admin.Controllers;
[Area("EduHome2Admin")]

public class NoticeController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public NoticeController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [Area("EduHome2Admin")]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Notices.ToListAsync());
    }
    [Area("EduHome2Admin")]
    public IActionResult Create()
    {
        return View();
    }
    [Area("EduHome2Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(NoticePostVM noticePost)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        Notice notice = _mapper.Map<Notice>(noticePost);
        await _context.Notices.AddAsync(notice);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int Id)
    {
        Notice? noticedb = await _context.Notices.FindAsync(Id);
        if (noticedb == null)
        {
            return NotFound();
        }
        return View(noticedb);
    }
    [Area("EduHome2Admin")]
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int Id)
    {
        Notice? noticedb = await _context.Notices.FindAsync(Id);
        if (noticedb == null)
        {
            return NotFound();
        }
        _context.Notices.Remove(noticedb);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [Area("EduHome2Admin")]
    public async Task<IActionResult> Update(int Id)
    {
        Notice? noticedb = await _context.Notices.FindAsync(Id);
        if (noticedb == null)
        {
            return NotFound();
        }
        return View(noticedb);

    }
    [Area("EduHome2Admin")]
    [ActionName("Update")]
    [HttpPost]
    public async Task<IActionResult> Update(int Id, Notice notice)
    {
        if (Id == notice.Id)
        {
            return BadRequest();
        }
        if (!ModelState.IsValid)
        {
            return View(notice);
        }
        Notice? noticedb = await _context.Notices.AsNoTracking().FirstOrDefaultAsync(s => s.Id == Id);
        if (noticedb == null)
        {
            return NotFound();
        }
        _context.Entry(notice).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }
}
