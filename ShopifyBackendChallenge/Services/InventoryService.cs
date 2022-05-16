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

        public IEnumerable<InventoryItem> GetInventoryItems()
        {
            return this.mapper.Map<IEnumerable<InventoryItem>>(this.inventoryRepository.GetInventoryItems());
        }

        public bool AddInventoryItems(IEnumerable<InventoryItem> inventoryItems)
        {
            return this.inventoryRepository.AddInventoryItems(this.mapper.Map<IEnumerable<InventoryItemStorageEntity>>(inventoryItems));
        }

        public bool DeleteInventoryItem(Guid id)
        {
            return this.inventoryRepository.DeleteInventoryItem(id);
        }

        public bool EditInventoryItem(InventoryItem inventoryItem)
        {
            return this.inventoryRepository.EditInventoryItem(this.mapper.Map<InventoryItemStorageEntity>(inventoryItem));
        }
    }
}
