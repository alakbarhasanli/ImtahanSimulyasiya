using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Contexts;
using Project.DAL.Entitites;

namespace ThirdProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class NewsController : Controller
    {
        private readonly INewsService _service;
        private readonly ThirdProjectDbContext _context;

        public NewsController(INewsService service, ThirdProjectDbContext context)
        {
            _service = service;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allNews = await _service.GetAllNewsAsync();
            return View(allNews);
        }
        public async Task<IActionResult> Info(int id)
        {
            var oneNews = await _service.GetNewsByIdAsync(id);
            return View(oneNews);
        }
        public async Task<IActionResult> Create(NewsCreateDto newsCreateDto)
        {
            ViewBag.category = _context.categories;
            if (ModelState.IsValid)
            {
             await _service.CreateAsync(newsCreateDto);
            return RedirectToAction("Index");
            }
                return View(newsCreateDto);
        }
        public async Task<IActionResult> Update(NewsCreateDto newsCreateDto,int id)
        {
            if (!ModelState.IsValid)
            {
                return View(newsCreateDto);
            }
            var existingNews = await _service.GetNewsByIdAsync(id);
            if(existingNews==null)
            {
                throw new Exception("News not found wit this id ");
            }
            await _service.UpdateAsync(newsCreateDto,id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete( int id)
        {
            ViewBag.category = _context.categories;
            var existingNews = await _service.GetNewsByIdAsync(id);
            if (existingNews == null)
            {
                throw new Exception("News not found wit this id ");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
