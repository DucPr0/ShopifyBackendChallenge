namespace ShopifyBackendChallenge.Models
{
    public class InventoryItemStorageEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Country { get; set; }

        public bool IsDeleted { get; set; }

        public string? DeleteReason { get; set; }

        public DateTime? DeleteTime { get; set; }
    }
}
