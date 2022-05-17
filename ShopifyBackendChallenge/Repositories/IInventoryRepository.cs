using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryItemStorageEntity>> GetInventoryItems();

        Task AddInventoryItems(IEnumerable<InventoryItemStorageEntity> inventoryItems);

        Task<bool> DeleteInventoryItem(Guid id);

        Task<bool> EditInventoryItem(InventoryItemStorageEntity inventoryItem);
    }
}
