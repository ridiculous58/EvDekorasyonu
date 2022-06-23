using EvDekorasyonu.Domain.Dtos;
using MediatR;

namespace EvDekorasyonu.Application.Features.Commands.CreateDekor;

public class CreateDekorCommand : IRequest<bool>
{
    public DekorDto DekorDto { get; set; }

    public CreateDekorCommand(DekorDto dekorDto)
    {
        DekorDto = dekorDto;
    }
}