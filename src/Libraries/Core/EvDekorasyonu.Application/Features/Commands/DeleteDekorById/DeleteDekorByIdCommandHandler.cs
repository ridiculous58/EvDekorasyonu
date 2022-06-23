using EvDekorasyonu.Application.Interfaces;
using MediatR;

namespace EvDekorasyonu.Application.Features.Commands.DeleteDekorById;

public class DeleteDekorByIdCommandHandler : IRequestHandler<DeleteDekorByIdCommand, bool>
{
    private readonly IDekorService _dekorService;
    public DeleteDekorByIdCommandHandler(IDekorService dekorService)
    {
        _dekorService = dekorService;
    }
    public async Task<bool> Handle(DeleteDekorByIdCommand request, CancellationToken cancellationToken)
    {
        return await _dekorService.DeleteById(request.Id);
    }
}