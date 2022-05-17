using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Services
{
    public interface IInventoryService
    {
        Task AddInventoryItems(IEnumerable<InventoryItemAddRequest> inventoryItems);

        Task<bool> DeleteInventoryItem(Guid id);

        Task<IEnumerable<InventoryItem>> GetInventoryItems();

        Task<bool> EditInventoryItem(InventoryItem inventoryItem);
    }
}
