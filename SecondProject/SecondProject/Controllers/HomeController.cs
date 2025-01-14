using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.BL.Services.Abstractions;


namespace SecondProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITecniciansService _service;

        public HomeController(ITecniciansService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allTechnician = await _service.GetAllTechnicianAsync();
            return View(allTechnician);
        }

        

       
    }
}
