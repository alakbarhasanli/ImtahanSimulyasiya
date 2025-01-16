using Microsoft.AspNetCore.Mvc;

namespace FourthProject.Areas.admin.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
