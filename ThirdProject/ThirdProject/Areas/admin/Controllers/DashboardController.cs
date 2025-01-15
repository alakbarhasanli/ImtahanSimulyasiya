using Microsoft.AspNetCore.Mvc;

namespace ThirdProject.Areas.admin.Controllers
{
        [Area("admin")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
