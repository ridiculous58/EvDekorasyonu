using MediatR;

namespace EvDekorasyonu.Application.Features.Commands.DeleteDekorById;

public class DeleteDekorByIdCommand : IRequest<bool>
{
    public string Id { get; set; }

    public DeleteDekorByIdCommand(string id)
    {
        Id = id;
    }
}