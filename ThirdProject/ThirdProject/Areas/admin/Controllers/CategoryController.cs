using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;

namespace ThirdProject.Areas.admin.Controllers
{
    [Area("admin")]
   
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCategory = await _service.GetAllCategoryAsync();
            return View(allCategory);
        }
        public async Task<IActionResult> Info(int id)
        {
            var oneCategory = await _service.GetCategoryByIdAsync(id);
            return View(oneCategory);
        }
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            if(!ModelState.IsValid)
            {
                return View(categoryCreateDto);
            }
            await _service.CreateAsync(categoryCreateDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
          
            var existingCategory = await _service.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                throw new Exception("Category not found wit this id ");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
