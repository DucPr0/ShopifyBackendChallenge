using AutoMapper;

using ShopifyBackendChallenge.Models;
using ShopifyBackendChallenge.Repositories;

namespace ShopifyBackendChallenge.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly IMapper mapper;

        public InventoryService(
            IInventoryRepository inventoryRepository,
            IMapper mapper)
        {
            this.inventoryRepository = inventoryRepository;
            this.mapper = mapper;
        } 

        public async Task<IEnumerable<InventoryItem>> GetInventoryItems()
        {
            var result = await this.inventoryRepository.GetInventoryItems();
            return this.mapper.Map<IEnumerable<InventoryItem>>(result);
        }

        public Task<bool> RestoreInventoryItem(int id)
        {
            return this.inventoryRepository.RestoreInventoryItem(id);
        }

        public Task AddInventoryItems(IEnumerable<InventoryItemAddRequest> inventoryItems)
        {
            return this.inventoryRepository.AddInventoryItems(this.mapper.Map<IEnumerable<InventoryItemStorageEntity>>(inventoryItems));
        }

        public Task<bool> DeleteInventoryItem(int id, InventoryItemDeleteRequest deleteRequest)
        {
            return this.inventoryRepository.DeleteInventoryItem(id, deleteRequest);
        }

        public Task<bool> EditInventoryItem(InventoryItemEditRequest editRequest)
        {
            return this.inventoryRepository.EditInventoryItem(editRequest);
        }

        public async Task<IEnumerable<InventoryItem>> GetDeletedItems()
        {
            var result = await this.inventoryRepository.GetDeletedItems();
            return this.mapper.Map<IEnumerable<InventoryItem>>(result);
        }
    }
}
