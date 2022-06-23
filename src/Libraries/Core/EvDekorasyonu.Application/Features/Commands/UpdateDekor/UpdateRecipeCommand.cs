using EvDekorasyonu.Application.Features.Queries.ViewModels;
using MediatR;

namespace EvDekorasyonu.Application.Features.Commands.UpdateDekor;

public class UpdateDekorCommand : IRequest<bool>
{
    public UpdateDekorCommand(DekorViewModel dekorViewModel)
    {
        DekorViewModel = dekorViewModel;
    }
    public DekorViewModel DekorViewModel { get; set; }
}
