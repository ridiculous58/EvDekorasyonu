using EvDekorasyonu.Application.Features.Commands.CreateDekor;
using EvDekorasyonu.Application.Features.Commands.DeleteDekorById;
using EvDekorasyonu.Application.Features.Commands.UpdateDekor;
using EvDekorasyonu.Application.Features.Queries.GetDekorAll;
using EvDekorasyonu.Application.Features.Queries.GetDekorById;
using EvDekorasyonu.Application.Features.Queries.ViewModels;
using EvDekorasyonu.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EvDekorasyonu.MVC.Areas.Admin.Controllers
{

    public class HomeController : BaseAdminController
    {
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(IMediator mediator, UserManager<IdentityUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Dekor()
        {
            var dekors = await _mediator.Send(new GetDekorAllQuery());
            return View(dekors);
        }
        [HttpGet]
        public async Task<IActionResult> DekorEdit(string id)
        {
            var dekors = await _mediator.Send(new GetDekorByIdQuery(id));
            return View(dekors);
        }
        [HttpPost]
        public async Task<IActionResult> DekorEdit(DekorViewModel dekor)
        {
            await _mediator.Send(new UpdateDekorCommand(dekor));
            return RedirectToAction("Dekor", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> DekorAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DekorAdd(DekorDto dekorDto)
        {
            await _mediator.Send(new CreateDekorCommand(dekorDto));
            return RedirectToAction("Dekor", "Home");
        }
        public async Task<IActionResult> DekorDelete(string id)
        {
            await _mediator.Send(new DeleteDekorByIdCommand(id));
            return RedirectToAction("Dekor");
        }

        public async Task<IActionResult> Profile()
        {
            return View(await _userManager.GetUserAsync(HttpContext.User));
        }
    }
}
