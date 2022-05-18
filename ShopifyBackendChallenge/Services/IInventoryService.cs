using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Services
{
    public interface IInventoryService
    {
        Task AddInventoryItems(IEnumerable<InventoryItemAddRequest> inventoryItems);

        Task<bool> DeleteInventoryItem(int id, InventoryItemDeleteRequest deleteRequest);

        Task<bool> RestoreInventoryItem(int id);

        Task<IEnumerable<InventoryItem>> GetInventoryItems();

        Task<bool> EditInventoryItem(InventoryItemEditRequest editRequest);

        Task<IEnumerable<InventoryItem>> GetDeletedItems();
    }
}
