using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EinsamerWanderer.API.Commands;
using EinsamerWanderer.API.Manager;
using EinsamerWanderer.API.Model;
using EinsamerWanderer.Shared;
using MediatR;

namespace EinsamerWanderer.API.Handler
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, Result>
    {
        private IItemManager _itemManager;
        private IMapper _mapper;

        public UpdateItemHandler(IItemManager itemManager, IMapper mapper)
        {
            _itemManager = itemManager;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Item>(request.UpdateItemRequest);
            item.Id = request.ItemId;
            return await _itemManager.Update(item, cancellationToken);
        }
    }
}