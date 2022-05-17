using Microsoft.EntityFrameworkCore;
using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IDbContextFactory<InventoryContext> dbContextFactory;

        public InventoryRepository(IDbContextFactory<InventoryContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<InventoryItemStorageEntity>> GetInventoryItems()
        {
            using var dbContext = this.dbContextFactory.CreateDbContext();
            return await dbContext.GetAllEntities().ToArrayAsync();
        }

        public async Task AddInventoryItems(IEnumerable<InventoryItemStorageEntity> inventoryItems)
        {
            using var dbContext = this.dbContextFactory.CreateDbContext();
            dbContext.AddRange(inventoryItems);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteInventoryItem(Guid id)
        {
            using var dbContext = this.dbContextFactory.CreateDbContext();

            var foundItem = await dbContext.FindAsync<InventoryItemStorageEntity>(id);
            if (foundItem != null)
            {
                dbContext.Remove(foundItem);
                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EditInventoryItem(InventoryItemStorageEntity inventoryItem)
        {
            using var dbContext = this.dbContextFactory.CreateDbContext();

            var foundItem = await dbContext.FindAsync<InventoryItemStorageEntity>(inventoryItem.Id);
            if (foundItem != null)
            {
                foundItem.Name = inventoryItem.Name;
                foundItem.OriginCountry = inventoryItem.OriginCountry;
                await dbContext.SaveChangesAsync();
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
}
