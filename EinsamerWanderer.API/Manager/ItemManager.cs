using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EinsamerWanderer.API.Model;
using EinsamerWanderer.API.Store;

namespace EinsamerWanderer.API.Manager
{
    public class ItemManager : IItemManager
    {
        private IItemStore _itemStore;

        public ItemManager(IItemStore itemStore)
        {
            _itemStore = itemStore;
        }

        public Task<List<Item>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}