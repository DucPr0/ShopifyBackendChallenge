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
            // Note to reader: Until ToArrayAsync is called, no calls have actually been made to the database.
            return await dbContext.GetAllEntities().Where(x => !x.IsDeleted).ToArrayAsync();
        }

        public async Task<IEnumerable<InventoryItemStorageEntity>> GetDeletedItems()
        {
            using var dbContext = this.dbContextFactory.CreateDbContext();
            return await dbContext.GetAllEntities().Where(x => x.IsDeleted).OrderByDescending(x => x.DeleteTime).Take(10).ToArrayAsync();
        }

        public async Task<bool> RestoreInventoryItem(int id)
        {
            using var dbContext = this.dbContextFactory.CreateDbContext();
            var foundItem = await dbContext.FindAsync<InventoryItemStorageEntity>(id);
            if (foundItem != null && foundItem.IsDeleted)
            {
                foundItem.IsDeleted = false;
                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task AddInventoryItems(IEnumerable<InventoryItemStorageEntity> inventoryItems)
        {
            using var dbContext = this.dbContextFactory.CreateDbContext();
            dbContext.AddRange(inventoryItems);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteInventoryItem(int id, InventoryItemDeleteRequest deleteRequest)
        {
            using var dbContext = this.dbContextFactory.CreateDbContext();

            var foundItem = await dbContext.FindAsync<InventoryItemStorageEntity>(id);
            if (foundItem != null && !foundItem.IsDeleted)
            {
                foundItem.IsDeleted = true;
                foundItem.DeleteReason = deleteRequest.DeleteReason;
                foundItem.DeleteTime = DateTime.Now;
                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EditInventoryItem(InventoryItemEditRequest editRequest)
        {
            using var dbContext = this.dbContextFactory.CreateDbContext();

            var foundItem = await dbContext.FindAsync<InventoryItemStorageEntity>(editRequest.Id);
            if (foundItem != null && !foundItem.IsDeleted)
            {
                foundItem.Name = editRequest.Name;
                foundItem.Country = editRequest.Country;
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
