using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.BL.Services.Implementations;
using Project.DAL.Contexts;

namespace FourthProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly FourthDbContext _context;

        public DoctorController(IDoctorService doctorService, FourthDbContext context)
        {
            _doctorService = doctorService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allDoctors = await _doctorService.GetAllAsync();
            return View(allDoctors);
        }
        public async Task<IActionResult> Info(int id)
        {
            var oneDoctor = await _doctorService.GetOneByIdAsync(id);
            return View(oneDoctor);
        }
        public async Task<IActionResult> Create(DoctorCreateDto doctor)
        {
            ViewBag.department = _context.departments;
            if (ModelState.IsValid)
            {
                await _doctorService.CreateAsync(doctor);
                return RedirectToAction("Index");


            }
            return View(doctor);
        }
        public async Task<IActionResult> Update(DoctorCreateDto doctorCreateDto, int id)
        {
            ViewBag.department = _context.departments;
            if (!ModelState.IsValid)
            {

                return View(doctorCreateDto);

            }
            var oneDoctor = await _doctorService.GetOneByIdAsync(id);
            if (oneDoctor == null)
            {
                throw new Exception("Doctor not found wit this id ");
            }
            await _doctorService.UpdateAsync(doctorCreateDto, id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.department = _context.departments;
            var oneDoctor = await _doctorService.GetOneByIdAsync(id);
            if (oneDoctor == null)
            {
                throw new Exception("Doctor not found wit this id ");
            }
            await _doctorService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
