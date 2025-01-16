using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;

namespace ThirdProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IActionResult> Register(RegisterCreateDto registerCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _authService.RegisterAsync(registerCreateDto);
                return RedirectToAction("Index", "Home");
            }
            return View(registerCreateDto);
        }
        public async Task<IActionResult> Login(LoginCreateDto loginCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _authService.LoginAsync(loginCreateDto);
                return RedirectToAction("Index", "Home");
            }
            return View(loginCreateDto);
        }
        public async Task<IActionResult> Logout()
        {
            {
                await _authService.Logoutasync();
                return RedirectToAction("Index", "Home");

            }
        }
    }
}
