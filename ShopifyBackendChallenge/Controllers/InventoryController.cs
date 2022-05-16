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
        public IEnumerable<InventoryItem> GetInventoryItems()
        {
            return this.inventoryService.GetInventoryItems();
        }

        [HttpPost]
        public bool AddInventoryItems([FromBody] IEnumerable<InventoryItem> inventoryItems)
        {
            return this.inventoryService.AddInventoryItems(inventoryItems);
        }

        [HttpDelete("{id}")]
        public bool DeleteInventoryItem(Guid id)
        {
            return this.inventoryService.DeleteInventoryItem(id);
        }

        [HttpPut]
        public bool EditInventoryItem([FromBody] InventoryItem inventoryItem)
        {
            return this.inventoryService.EditInventoryItem(inventoryItem);
        }
    }
}
