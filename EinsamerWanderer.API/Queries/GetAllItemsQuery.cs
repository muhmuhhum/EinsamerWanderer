using EinsamerWanderer.API.Model;
using MediatR;
using System.Collections.Generic;

namespace EinsamerWanderer.API.Queries
{
    public class GetAllItemsQuery : IRequest<List<Item>>
    {
    }
}
