using FirstProject.BL.DTOs;
using FirstProject.BL.Services.Abstractions;
using FirstProject.DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectMVC.Areas.admin.Controllers
{
    [Area("admin")]
    public class CardItemController : Controller
    {
        private readonly ICardItemService _service;

        public CardItemController(ICardItemService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCArdItems = await _service.GetAllCArdItemAsync();
            return View(allCArdItems);
        }
        public async Task<IActionResult> Info(int id)
        {
            var oneCardItem = await  _service.GetCardItemByIdAsync(id);
            return View(oneCardItem);
        }
        public async Task<IActionResult> Create(CardItemCreateDto cardItemCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateCardItemAsync(cardItemCreateDto);
                return RedirectToAction("Index");

            }
            return View(cardItemCreateDto);
        }
        public async Task<IActionResult> Update(int id, CardItemCreateDto cardItemCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateCardItemAsync(cardItemCreateDto, id);
                return RedirectToAction("Index");

            }

            return View(cardItemCreateDto);
        }
        public async Task<IActionResult> SoftDelete(int id)
        {

            var result = await _service.SoftDeleteCardItemAsync(id);
            if (!result)
            {
                throw new Exception("Doesnt SoftDelete CardItem");
            }
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> HardDelete(int id)
        {

            var result = await _service.HardDeleteCardItemAsync(id);
            if (!result)
            {
                throw new Exception("Doesnt HardDelete CardItem");
            }
            return RedirectToAction("Index");

        }
    }
}
