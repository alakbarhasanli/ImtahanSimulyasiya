using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;

namespace FourthProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Register(RegisterAuthDto registerAuthDto)
        {
            if (ModelState.IsValid)
            {
                await _service.RegisterAsync(registerAuthDto);
                return RedirectToAction("Index", "Home");
            }
            return View(registerAuthDto);
        }
        public async Task<IActionResult> Login(LoginAuthDto loginAuthDto)
        {
            if (ModelState.IsValid)
            {
                await _service.LoginAsync(loginAuthDto);
                return RedirectToAction("Index", "Home");
            }
            return View(loginAuthDto);
        }
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Index", "Home");

        }

    }
}
