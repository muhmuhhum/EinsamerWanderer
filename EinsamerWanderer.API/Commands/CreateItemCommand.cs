using EinsamerWanderer.API.Request;
using EinsamerWanderer.API.Response;
using EinsamerWanderer.Shared;
using MediatR;

namespace EinsamerWanderer.API.Commands
{
    public class CreateItemCommand : IRequest<Result<ItemResponse>>
    {
        public CreateItemRequest CreateItemRequest { get; set; }

        public CreateItemCommand(CreateItemRequest createItemRequest)
        {
            CreateItemRequest = createItemRequest;
        }
    }
}