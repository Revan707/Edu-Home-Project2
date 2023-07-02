using Microsoft.AspNetCore.Mvc;

namespace EduHome2.UI.Areas.EduHome2Admin.Controllers;
[Area("EduHome2Admin")]

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
