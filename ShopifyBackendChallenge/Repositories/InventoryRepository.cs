using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryContext inventoryContext;
        

        public InventoryRepository(InventoryContext inventoryContext)
        {
            this.inventoryContext = inventoryContext;
        }

        public IEnumerable<InventoryItemStorageEntity> GetInventoryItems()
        {
            return this.inventoryContext.Items.ToArray();
        }

        public bool AddInventoryItems(IEnumerable<InventoryItemStorageEntity> inventoryItems)
        {
            this.inventoryContext.Items.AddRange(inventoryItems);
            this.inventoryContext.SaveChanges();
            return true;
        }

        public bool DeleteInventoryItem(Guid id)
        {
            this.inventoryContext.Items.Remove(this.inventoryContext.Items.Find(id));
            this.inventoryContext.SaveChanges();
            return true;
        }

        public bool EditInventoryItem(InventoryItemStorageEntity inventoryItem)
        {
            this.inventoryContext.Entry(inventoryItem).Entity.Name = inventoryItem.Name;
            this.inventoryContext.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            this.inventoryContext.Dispose();
        }
    }
}
