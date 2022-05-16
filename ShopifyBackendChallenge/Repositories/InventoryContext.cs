using ShopifyBackendChallenge.Mappings;
using ShopifyBackendChallenge.Models;
using System.Data.Entity;

namespace ShopifyBackendChallenge.Repositories
{
    public class InventoryContext : DbContext
    {
        public DbSet<InventoryItemStorageEntity> Items { get; set; }

        public InventoryContext() : 
            base("Data Source=localhost;Initial Catalog=TestDb;User Id=username;Password=passy123")
        {
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Configurations.Add(new InventoryItemStorageMapping());
        }
    }
}
