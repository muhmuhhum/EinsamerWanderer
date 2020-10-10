using EinsamerWanderer.API.Model;
using Microsoft.EntityFrameworkCore;

namespace EinsamerWanderer.API.DbContext
{
    public class EinsamerWandererDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EinsamerWandererDbContext(DbContextOptions<EinsamerWandererDbContext> options)
            : base(options)
        { }

        public DbSet<Item> Items;
    }
}