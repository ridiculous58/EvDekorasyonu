using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvDekorasyonu.Application.Features.Queries.ViewModels;
using MediatR;

namespace EvDekorasyonu.Application.Features.Queries.GetDekorById
{
    public class GetDekorByIdQuery : IRequest<DekorViewModel>
    {
        public string Id { get; set; }

        public GetDekorByIdQuery(string id)
        {
            Id = id;
        }
    }
}
