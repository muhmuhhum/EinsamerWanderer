using EinsamerWanderer.Auth.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EinsamerWanderer.Auth.Context
{
    public class EWContext : DbContext
    {

        public DbSet<EWUser> Users { get; set; }

        public DbSet<IdentityUserLogin<Guid>> UserLogins { get; set; }

        public DbSet<IdentityUserToken<Guid>> UserTokens { get; set; }
        public EWContext(DbContextOptions<EWContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var maxKeyLength = 128;
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EWUser>(b => b.HasKey(x => x.Id));

            modelBuilder.Entity<IdentityUserLogin<Guid>>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });

                if (maxKeyLength > 0)
                {
                    b.Property(l => l.LoginProvider).HasMaxLength(maxKeyLength);
                    b.Property(l => l.ProviderKey).HasMaxLength(maxKeyLength);
                }

                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity<IdentityUserToken<Guid>>(b =>
            {
                b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

                if (maxKeyLength > 0)
                {
                    b.Property(t => t.LoginProvider).HasMaxLength(maxKeyLength);
                    b.Property(t => t.Name).HasMaxLength(maxKeyLength);
                }
                b.ToTable("AspNetUserTokens");
            });
        }
    }
}
