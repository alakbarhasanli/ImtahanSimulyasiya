using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace ThirdProject.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

     
    }
}
