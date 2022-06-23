using AutoMapper;
using EvDekorasyonu.Application.Features.Queries.ViewModels;
using EvDekorasyonu.Application.Interfaces;
using EvDekorasyonu.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EvDekorasyonu.Application.Features.Queries.GetDekorAll;

public class GetDekorAllQueryHandler : IRequestHandler<GetDekorAllQuery, IEnumerable<DekorViewModel>>
{
    private readonly IDekorService _dekorService;
    private readonly IMapper _mapper;

    public GetDekorAllQueryHandler(IDekorService dekorService, IMapper mapper)
    {
        _dekorService = dekorService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DekorViewModel>> Handle(GetDekorAllQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Dekor> table = _dekorService.Table;

        table = table.Include(x => x.DekorCategory); // eagle loading

        if (request.IsOrderByDescendingForCreatedDate)
        {
            table = table.OrderByDescending(x => x.CreatedDate);
        }

        var dekors = await Task.Run(() => table.AsEnumerable(), cancellationToken);

        return _mapper.Map<IEnumerable<Dekor>, IEnumerable<DekorViewModel>>(dekors);
    }
}