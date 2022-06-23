using EvDekorasyonu.Application.Features.Queries.GetDekorAll;
using EvDekorasyonu.Application.Features.Queries.GetDekorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YemekTarifi.MVC.Controllers;

public class DekorController : Controller
{
    private readonly IMediator _mediator;
    public DekorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Dekors()
    {
        var recipes = await  _mediator.Send(new GetDekorAllQuery());
        return View(recipes);
    }
    
    public async Task<IActionResult> DekorDetail(string id)
    {
        var recipe = await  _mediator.Send(new GetDekorByIdQuery(id));
        return View(recipe);
    }
    
}