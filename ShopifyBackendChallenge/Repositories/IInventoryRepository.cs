using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Repositories
{
    public interface IInventoryRepository : IDisposable
    {
        IEnumerable<InventoryItemStorageEntity> GetInventoryItems();

        bool AddInventoryItems(IEnumerable<InventoryItemStorageEntity> inventoryItems);

        bool DeleteInventoryItem(Guid id);

        bool EditInventoryItem(InventoryItemStorageEntity inventoryItem);
    }
}
