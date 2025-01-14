using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;

namespace SecondProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class ServiceController : Controller
    {
        private readonly IService _service;

        public ServiceController(IService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allservice = await _service.GetAllServiceAsync();
            return View(allservice);
        }
        public async Task<IActionResult> Info(int id)
        {
            var existingService = await _service.GetOneServiceAsync(id);
            return View(existingService);
        }
        public async Task<IActionResult> Create(ServiceCreatedto serviceCreatedto)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateServiceAsync(serviceCreatedto);
                return RedirectToAction("Index");

            }
            return View(serviceCreatedto);
        }
        public async Task<IActionResult> Update(ServiceCreatedto serviceCreatedto, int id)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateServiceAsync(serviceCreatedto, id);
                return RedirectToAction("Index");

            }
            return View(serviceCreatedto);
        }
        public async Task<IActionResult> Delete(int id)
        {

            await _service.DeleteServiceAsync(id);
            return RedirectToAction("Index");



        }
    }
}
