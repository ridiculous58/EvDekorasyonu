using AutoMapper;
using EvDekorasyonu.Application.Interfaces;
using EvDekorasyonu.Domain.Entities;
using MediatR;

namespace EvDekorasyonu.Application.Features.Commands.CreateDekor
{
    public class CreateDekorCommandHandler : IRequestHandler<CreateDekorCommand, bool>
    {
        private readonly IDekorService _dekorService;
        private readonly IMapper _mapper;

        public CreateDekorCommandHandler(IDekorService dekorService, IMapper mapper)
        {
            _dekorService = dekorService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateDekorCommand request, CancellationToken cancellationToken)
        {
            var dekor = _mapper.Map<Dekor>(request.DekorDto);
            await _dekorService.InsertAsync(dekor);
            return true;
        }
    }

}
