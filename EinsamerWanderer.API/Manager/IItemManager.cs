using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EinsamerWanderer.API.Model;

namespace EinsamerWanderer.API.Manager
{
    public interface IItemManager
    {
        public Task<List<Item>> GetAll();
        public Task<Item> GetItemById(Guid id);
    }
}