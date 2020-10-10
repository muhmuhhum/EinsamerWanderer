using EinsamerWanderer.API.DbContext;
using EinsamerWanderer.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EinsamerWanderer.API.Store
{
    public class ItemStore : IItemStore
    {
        private EinsamerWandererDbContext _dbContext;

        public ItemStore(EinsamerWandererDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Item>> GetAll()
        {
            return await _dbContext.Items.ToListAsync();
        }

        public async Task<Item> GetItemById(Guid itemId)
        {
            return await _dbContext.Items.FirstOrDefaultAsync(item => item.Id == itemId);
        }
    }
}