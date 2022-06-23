using EvDekorasyonu.Application.Features.Queries.GetDekorAll;
using EvDekorasyonu.Application.Features.Queries.GetDekorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EvDekorasyonu.MVC.Controllers;

public class DekorController : Controller
{
    private readonly IMediator _mediator;
    public DekorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Dekors()
    {
        var dekors = await _mediator.Send(new GetDekorAllQuery());
        return View(dekors);
    }

    public async Task<IActionResult> DekorDetail(string id)
    {
        var dekor = await _mediator.Send(new GetDekorByIdQuery(id));
        return View(dekor);
    }

}