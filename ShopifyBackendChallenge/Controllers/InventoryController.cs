using AutoMapper;
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
        private readonly IMapper mapper;

        public InventoryController(
            IInventoryService inventoryService,
            IMapper mapper)
        {
            this.inventoryService = inventoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<InventoryItemResponse>> GetInventoryItems()
        {
            var result = await this.inventoryService.GetInventoryItems();
            return this.mapper.Map<IEnumerable<InventoryItemResponse>>(result);
        }

        [HttpGet("deleted")]
        public async Task<IEnumerable<InventoryItem>> GetDeletedItems()
        {
            return await this.inventoryService.GetDeletedItems();
        }

        [HttpPut("restore/{id}")]
        public async Task<bool> RestoreInventoryItem(int id)
        {
            return await this.inventoryService.RestoreInventoryItem(id);
        }

        [HttpPost]
        public async void AddInventoryItems([FromBody] IEnumerable<InventoryItemAddRequest> inventoryItems)
        {
            await this.inventoryService.AddInventoryItems(inventoryItems);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteInventoryItem(int id, InventoryItemDeleteRequest deleteRequest)
        {
            return await this.inventoryService.DeleteInventoryItem(id, deleteRequest);
        }

        [HttpPut]
        public async Task<bool> EditInventoryItem([FromBody] InventoryItemEditRequest editRequest)
        {
            return await this.inventoryService.EditInventoryItem(editRequest);
        }
    }
}
