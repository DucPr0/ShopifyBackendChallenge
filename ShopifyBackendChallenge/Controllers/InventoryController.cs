using Microsoft.AspNetCore.Mvc;

using ShopifyBackendChallenge.Services;
using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<InventoryItem>> GetInventoryItems()
        {
            return await this.inventoryService.GetInventoryItems();
        }

        [HttpPost]
        public async void AddInventoryItems([FromBody] IEnumerable<InventoryItem> inventoryItems)
        {
            await this.inventoryService.AddInventoryItems(inventoryItems);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteInventoryItem(Guid id)
        {
            return await this.inventoryService.DeleteInventoryItem(id);
        }

        [HttpPut]
        public async Task<bool> EditInventoryItem([FromBody] InventoryItem inventoryItem)
        {
            return await this.inventoryService.EditInventoryItem(inventoryItem);
        }
    }
}
