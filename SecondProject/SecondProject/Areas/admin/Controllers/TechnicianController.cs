using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.BL.Services.Implementations;
using Project.DAL.Contexts;

namespace SecondProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class TechnicianController : Controller
    {
        private readonly ITecniciansService _service;
        private readonly SecondProjectDbContext _context;

        public TechnicianController(ITecniciansService service, SecondProjectDbContext context)
        {
            _service = service;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var alltechnician = await _service.GetAllTechnicianAsync();
            return View(alltechnician);
        }
        public async Task<IActionResult> Info(int id)
        {
            var existingtechnician = await _service.GetOneTechnicianAsync(id);
            return View(existingtechnician);
        }
        public async Task<IActionResult> Create(TechnicianCreateDto technicianCreateDto)
        {
            ViewBag.services = _context.services;
            if (ModelState.IsValid)
            {
                await _service.CreateTechnicianAsync(technicianCreateDto);
                return RedirectToAction("Index");

            }
            return View(technicianCreateDto);
        }
        public async Task<IActionResult> Update(TechnicianCreateDto technicianCreateDto, int id)
        {
            if (ModelState.IsValid)
            {
                ViewBag.services = _context.services;
                await _service.UpdateTechnicianAsync(technicianCreateDto, id);
                return RedirectToAction("Index");

            }
            return View(technicianCreateDto);
        }
        public async Task<IActionResult> Delete(int id)
        {

            await _service.DeleteTechnicianAsync(id);
            return RedirectToAction("Index");



        }
    }
}
