using EvDekorasyonu.Application.Interfaces;
using EvDekorasyonu.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YemekTarifi.MVC.Controllers
{
    public class IdentityController : Controller
    {

        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {

            var registerDto = new RegisterDto
            {
                Email = "email@gmail.com",
                Password = "********"
            };

            return View(registerDto);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto? registerDto)
        {
            if (registerDto == null)
                return BadRequest();

            await _identityService.Register(registerDto,new string[] { "Admin" });

            return RedirectToAction("Index", "Home");
        }


        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            var loginDto = new LoginDto("ece@ece.com","Ece@1234",true);
            return View(loginDto);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto? loginDto)
        {
            if (loginDto == null)
                return BadRequest();

            await _identityService.Login(loginDto);

            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _identityService.Logout();
            return RedirectToAction("Index", "Home");
        }


    }
}
