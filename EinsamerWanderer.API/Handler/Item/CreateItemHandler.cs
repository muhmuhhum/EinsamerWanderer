using AutoMapper;
using EinsamerWanderer.API.Commands;
using EinsamerWanderer.API.Manager;
using EinsamerWanderer.API.Model;
using EinsamerWanderer.API.Response;
using EinsamerWanderer.Shared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EinsamerWanderer.API.Handler
{
    public class CreateItemHandler : IRequestHandler<CreateItemCommand, Result<ItemResponse>>
    {
        private IItemManager _itemManager;
        private IMapper _mapper;

        public CreateItemHandler(IItemManager itemManager, IMapper mapper)
        {
            _itemManager = itemManager;
            _mapper = mapper;
        }

        public async Task<Result<ItemResponse>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {

            return await _itemManager.Create(_mapper.Map<Item>(request.CreateItemRequest), cancellationToken);
        }
    }
}