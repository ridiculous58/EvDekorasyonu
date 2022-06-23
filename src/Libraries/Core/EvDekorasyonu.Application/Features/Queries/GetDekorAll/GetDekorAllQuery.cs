using EvDekorasyonu.Application.Features.Queries.ViewModels;
using MediatR;

namespace EvDekorasyonu.Application.Features.Queries.GetDekorAll;

public class GetDekorAllQuery : IRequest<IEnumerable<DekorViewModel>>
{
    public bool IsOrderByDescendingForCreatedDate { get; set; }

    public GetDekorAllQuery(bool isOrderByDescendingForCreatedDate = false)
    {
        IsOrderByDescendingForCreatedDate = isOrderByDescendingForCreatedDate;
    }
}