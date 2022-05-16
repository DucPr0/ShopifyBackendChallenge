using System.Data.Entity.ModelConfiguration;

using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Mappings
{
    public class InventoryItemStorageMapping : EntityTypeConfiguration<InventoryItemStorageEntity>
    {
        public InventoryItemStorageMapping()
        {
            this.ToTable("Inventory");

            this.HasKey(t => t.Id);

            this.Property(t => t.Id).HasColumnName("id");

            this.Property(t => t.Name).HasColumnName("name");
        }
    }
}
