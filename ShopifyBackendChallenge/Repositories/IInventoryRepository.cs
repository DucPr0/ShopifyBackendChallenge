using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryItemStorageEntity>> GetInventoryItems();

        Task<IEnumerable<InventoryItemStorageEntity>> GetDeletedItems();

        Task<bool> RestoreInventoryItem(int id);

        Task AddInventoryItems(IEnumerable<InventoryItemStorageEntity> inventoryItems);

        Task<bool> DeleteInventoryItem(int id, InventoryItemDeleteRequest deleteRequest);

        Task<bool> EditInventoryItem(InventoryItemEditRequest editRequest);
    }
}
