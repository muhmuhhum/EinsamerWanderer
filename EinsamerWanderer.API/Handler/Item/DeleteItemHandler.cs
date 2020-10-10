using System.Threading;
using System.Threading.Tasks;
using EinsamerWanderer.API.Commands;
using EinsamerWanderer.API.Manager;
using EinsamerWanderer.Shared;
using MediatR;

namespace EinsamerWanderer.API.Handler
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, Result>
    {
        private IItemManager _itemManager;

        public DeleteItemHandler(IItemManager itemManager)
        {
            _itemManager = itemManager;
        }

        public async Task<Result> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            return await _itemManager.Delete(request.ItemId, cancellationToken);
        }
    }
}