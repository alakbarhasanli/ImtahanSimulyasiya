using Microsoft.AspNetCore.Mvc;

namespace FourthProject.Areas.admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
