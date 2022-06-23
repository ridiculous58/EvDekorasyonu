using AutoMapper;
using EvDekorasyonu.Application.Features.Queries.ViewModels;
using EvDekorasyonu.Application.Interfaces;
using MediatR;

namespace EvDekorasyonu.Application.Features.Queries.GetDekorById
{
    public class GetDekorByIdQueryHandler : IRequestHandler<GetDekorByIdQuery, DekorViewModel>
    {
        private readonly IDekorService _dekorService;
        private readonly IMapper _mapper;
        public GetDekorByIdQueryHandler(IDekorService dekorService, IMapper mapper)
        {
            _dekorService = dekorService;
            _mapper = mapper;
        }

        public async Task<DekorViewModel> Handle(GetDekorByIdQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.Id, out var id))
                return null;

            var dekor = await _dekorService.GetDekorByIdAsync(id);
            return _mapper.Map<DekorViewModel>(dekor);
        }
    }
}
