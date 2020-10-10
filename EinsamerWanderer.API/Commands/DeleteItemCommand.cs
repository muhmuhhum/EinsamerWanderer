using System;
using EinsamerWanderer.Shared;
using MediatR;

namespace EinsamerWanderer.API.Commands
{
    public class DeleteItemCommand : IRequest<Result>
    {
        public Guid ItemId { get; private set; }

        public DeleteItemCommand(Guid itemId)
        {
            ItemId = itemId;
        }
    }
}