using Microsoft.AspNetCore.Mvc;

namespace FourthProject.Areas.admin.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
