using System;
using EinsamerWanderer.API.Request;
using EinsamerWanderer.Shared;
using MediatR;

namespace EinsamerWanderer.API.Commands
{
    public class UpdateItemCommand : IRequest<Result>
    {
        public Guid ItemId { get; set; }
        public UpdateItemRequest UpdateItemRequest { get; set; }
        public UpdateItemCommand(Guid itemId, UpdateItemRequest updateItemRequest)
        {
            ItemId = itemId;
            UpdateItemRequest = updateItemRequest;
        }
    }
}