using ShopifyBackendChallenge.Mappings;
using ShopifyBackendChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopifyBackendChallenge.Repositories
{
    public class InventoryContext : DbContext
    {
        private DbSet<InventoryItemStorageEntity> Items { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : 
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InventoryItemStorageMapping());
        }

        public IQueryable<InventoryItemStorageEntity> GetAllEntities()
        {
            return this.Items.AsNoTracking();
        }
    }
}
