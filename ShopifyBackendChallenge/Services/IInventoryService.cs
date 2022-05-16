using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Services
{
    public interface IInventoryService
    {
        bool AddInventoryItems(IEnumerable<InventoryItem> inventoryItems);

        bool DeleteInventoryItem(Guid id);

        IEnumerable<InventoryItem> GetInventoryItems();

        bool EditInventoryItem(InventoryItem inventoryItem);
    }
}
