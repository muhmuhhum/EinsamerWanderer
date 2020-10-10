using System;
using EinsamerWanderer.API.Model;
using MediatR;

namespace EinsamerWanderer.API.Queries
{
    public class GetItemByIdQuery : IRequest<Item>
    {
        public Guid ItemId { get; set; }

        public GetItemByIdQuery(Guid itemId)
        {
            ItemId = itemId;
        }
    }
}