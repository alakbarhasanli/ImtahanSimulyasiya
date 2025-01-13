using System.Diagnostics;
using FirstProject.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICardItemService _service;

        public HomeController(ICardItemService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allcardItems =await  _service.GetAllCArdItemAsync();
            return View(allcardItems);
        }

      
        
    }
}
