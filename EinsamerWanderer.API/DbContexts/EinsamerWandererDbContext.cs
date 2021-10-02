using EinsamerWanderer.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EinsamerWanderer.API.DbContext
{
    public class EinsamerWandererDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private ILoggerFactory _loggerFactory;

        public EinsamerWandererDbContext(DbContextOptions<EinsamerWandererDbContext> options,
            ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Item> Items { get; set; }
    }
}