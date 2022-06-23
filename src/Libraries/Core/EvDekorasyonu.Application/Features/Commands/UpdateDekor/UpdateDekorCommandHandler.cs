using AutoMapper;
using EvDekorasyonu.Application.Features.Queries.ViewModels;
using EvDekorasyonu.Application.Interfaces;
using EvDekorasyonu.Domain.Entities;
using MediatR;

namespace EvDekorasyonu.Application.Features.Commands.UpdateDekor;

public class UpdateDekorCommandHandler : IRequestHandler<UpdateDekorCommand, bool>
{
    private readonly IDekorService _dekorService;
    private readonly IMapper _mapper;
    public UpdateDekorCommandHandler(IDekorService dekorService, IMapper mapper)
    {
        _dekorService = dekorService;
        _mapper = mapper;
    }
    public async Task<bool> Handle(UpdateDekorCommand request, CancellationToken cancellationToken)
    {
        var dekor = _mapper.Map<DekorViewModel, Dekor>(request.DekorViewModel);
        await _dekorService.UpdateAsync(dekor);
        return true;
    }
}