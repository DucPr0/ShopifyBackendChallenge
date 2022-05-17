using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Services
{
    public interface IInventoryService
    {
        Task AddInventoryItems(IEnumerable<InventoryItemAddRequest> inventoryItems);

        Task<bool> DeleteInventoryItem(int id);

        Task<IEnumerable<InventoryItem>> GetInventoryItems();

        Task<bool> EditInventoryItem(InventoryItem inventoryItem);
    }
}
