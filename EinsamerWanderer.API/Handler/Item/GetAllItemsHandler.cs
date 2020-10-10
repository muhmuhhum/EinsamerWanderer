using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EinsamerWanderer.API.Manager;
using EinsamerWanderer.API.Model;
using EinsamerWanderer.API.Queries;
using MediatR;

namespace EinsamerWanderer.API.Handler
{
    public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery, List<Item>>
    {
        private IItemManager _itemManager;

        public GetAllItemsHandler(IItemManager itemManager)
        {
            _itemManager = itemManager;
        }

        public Task<List<Item>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            return _itemManager.GetAll(cancellationToken);
        }
    }
}