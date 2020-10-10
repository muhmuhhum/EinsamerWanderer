using EinsamerWanderer.API.DbContext;
using EinsamerWanderer.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EinsamerWanderer.Shared.Exception;

namespace EinsamerWanderer.API.Store
{
    public class ItemStore : IItemStore
    {
        private EinsamerWandererDbContext _dbContext;
        private IMapper _mapper;

        public ItemStore(EinsamerWandererDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<Item>> GetAll(CancellationToken cancellationToken)
        {
            if (_dbContext.Items is null)
            {
                return new List<Item>();
            }
            return await _dbContext.Items.ToListAsync(cancellationToken);
        }

        public async Task<Item> GetItemById(Guid itemId, CancellationToken cancellationToken)
        {
            if (_dbContext.Items is null)
            {
                return null;
            }
            return await _dbContext.Items.FirstOrDefaultAsync(item => item.Id == itemId, cancellationToken);
        }

        public async Task<Item> Create(Item item, CancellationToken cancellationToken)
        {
            await _dbContext.Items.AddAsync(item, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return item;
        }

        public async Task Update(Item item, CancellationToken cancellationToken)
        {
            var dbItem = await GetItemById(item.Id, cancellationToken);
            if (dbItem is null)
            {
                throw new EntityNotFoundException(nameof(Item), item.Id);
            }
            _mapper.Map(item, dbItem);
            _dbContext.Update(dbItem);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Remove(Guid itemId, CancellationToken cancellationToken)
        {
            var item = await GetItemById(itemId, cancellationToken);
            if (item is null)
            {
                throw new EntityNotFoundException(nameof(Item), itemId);
            }
            _dbContext.Remove(item);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}