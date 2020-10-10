using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EinsamerWanderer.API.Model;

namespace EinsamerWanderer.API.Store
{
    public interface IItemStore
    {
        Task<List<Item>> GetAll(CancellationToken cancellationToken);
        Task<Item> GetItemById(Guid itemId, CancellationToken cancellationToken);
        Task<Item> Create(Item item, CancellationToken cancellationToken);
        Task Update(Item item, CancellationToken cancellationToken);
        Task Remove(Guid itemId, CancellationToken cancellationToken);
    }
}