using AutoMapper;
using EinsamerWanderer.API.Model;
using EinsamerWanderer.API.Response;
using EinsamerWanderer.API.Store;
using EinsamerWanderer.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EinsamerWanderer.Shared.Exception;

namespace EinsamerWanderer.API.Manager
{
    public class ItemManager : IItemManager
    {
        private IItemStore _itemStore;
        private IMapper _mapper;

        public ItemManager(IItemStore itemStore, IMapper mapper)
        {
            _itemStore = itemStore;
            _mapper = mapper;
        }

        public async Task<List<Item>> GetAll(CancellationToken cancellationToken)
        {
            return await _itemStore.GetAll(cancellationToken);
        }

        public async Task<Item> GetItemById(Guid id, CancellationToken cancellationToken)
        {
            return await _itemStore.GetItemById(id, cancellationToken);
        }

        public async Task<Result<ItemResponse>> Create(Item item, CancellationToken cancellationToken)
        {
            var result = await _itemStore.Create(item, cancellationToken);
            return Result<ItemResponse>.SuccessData(_mapper.Map<ItemResponse>(result));
        }

        public async Task<Result> Update(Item item, CancellationToken cancellationToken)
        {
            try
            {
                var foundItem = await _itemStore.GetItemById(item.Id, cancellationToken);
                if (foundItem is null)
                {
                    return Result.Failed(new List<EWErrror>
                        {new EWErrror {Code = "EntityNotFound", Message = $"Entity with Id {item.Id} was not found"}});
                }
                await _itemStore.Update(item, cancellationToken);
                return Result.Success;
            }
            catch (EntityNotFoundException entityNotFound)
            {
                return Result.Failed(new List<EWErrror>
                {
                    new EWErrror
                    {
                        Code = "EntityNotFound",
                        Message = $"{entityNotFound.TypeName} with Id {entityNotFound.EntityId} was not found"
                    }
                });
            }
        }

        public async Task<Result> Delete(Guid itemId, CancellationToken cancellationToken)
        {
            try
            {
                await _itemStore.Remove(itemId, cancellationToken);
                return Result.Success;
            }
            catch (EntityNotFoundException entityNotFound)
            {
                return Result.Failed(new List<EWErrror>
                {
                    new EWErrror
                    {
                        Code = "EntityNotFound",
                        Message = $"{entityNotFound.TypeName} with Id {entityNotFound.EntityId} was not found"
                    }
                });
            }
            
        }
    }
}