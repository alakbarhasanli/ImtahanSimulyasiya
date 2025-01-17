using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;

namespace FourthProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            var allDepartment = await _departmentService.GetAllAsync();
            return View(allDepartment);
        }
        public async Task<IActionResult> Info(int id)
        {
            var oneDepartment = await _departmentService.GetOneByIdAsync(id);
            return View(oneDepartment);
        }
        public async Task<IActionResult> Create(DepartmentCreateDto departmentCreateDto)
        {
            if(ModelState.IsValid)
            {
             await _departmentService.CreateAsync(departmentCreateDto);
             return RedirectToAction("Index");


            }
            return View(departmentCreateDto);
        }
        public async Task<IActionResult> Update(DepartmentCreateDto departmentCreateDto, int id)
        {
            var oneDepartment = await _departmentService.GetOneByIdAsync(id);
            if (ModelState.IsValid)
            {
                await _departmentService.UpdateAsync(departmentCreateDto,id);
                return RedirectToAction("Index");


            }
            return View(departmentCreateDto);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var oneDepartment = await _departmentService.GetOneByIdAsync(id);
            await _departmentService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
