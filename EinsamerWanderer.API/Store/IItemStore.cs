using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EinsamerWanderer.API.Model;

namespace EinsamerWanderer.API.Store
{
    public interface IItemStore
    {
        Task<List<Item>> GetAll();
        Task<Item> GetItemById(Guid itemId);
    }
}