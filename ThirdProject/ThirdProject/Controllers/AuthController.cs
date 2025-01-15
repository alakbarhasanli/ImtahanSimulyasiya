using Microsoft.AspNetCore.Mvc;

namespace ThirdProject.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
