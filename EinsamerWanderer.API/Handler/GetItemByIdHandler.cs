using System.Threading;
using System.Threading.Tasks;
using EinsamerWanderer.API.Manager;
using EinsamerWanderer.API.Model;
using EinsamerWanderer.API.Queries;
using MediatR;

namespace EinsamerWanderer.API.Handler
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, Item>
    {
        private IItemManager _itemManager;

        public GetItemByIdHandler(IItemManager itemManager)
        {
            _itemManager = itemManager;
        }

        public async Task<Item> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await _itemManager.GetItemById(request.ItemId);
        }
    }
}