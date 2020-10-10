using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EinsamerWanderer.API.Model;
using EinsamerWanderer.API.Response;
using EinsamerWanderer.Shared;

namespace EinsamerWanderer.API.Manager
{
    public interface IItemManager
    {
        public Task<List<Item>> GetAll(CancellationToken cancellationToken);
        public Task<Item> GetItemById(Guid id, CancellationToken cancellationToken);
        Task<Result<ItemResponse>> Create(Item item, CancellationToken cancellationToken);
        Task<Result> Update(Item item, CancellationToken cancellationToken);
        Task<Result> Delete(Guid itemId, CancellationToken cancellationToken);
    }
}