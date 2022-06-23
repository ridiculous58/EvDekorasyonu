using EvDekorasyonu.Application.Features.Queries.GetDekorAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvDekorasyonu.MVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var dekors = await _mediator.Send(new GetDekorAllQuery(true));
            return View(dekors);
        }


        public IActionResult DekorDetail()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
