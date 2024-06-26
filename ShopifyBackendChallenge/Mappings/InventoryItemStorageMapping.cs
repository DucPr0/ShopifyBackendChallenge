﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShopifyBackendChallenge.Models;

namespace ShopifyBackendChallenge.Mappings
{
    public class InventoryItemStorageMapping : IEntityTypeConfiguration<InventoryItemStorageEntity>
    {
        public void Configure(EntityTypeBuilder<InventoryItemStorageEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Inventory");

            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Name).HasColumnName("name");

            builder.Property(x => x.Country).HasColumnName("country");

            builder.Property(x => x.IsDeleted).HasColumnName("isDeleted");

            builder.Property(x => x.DeleteReason).HasColumnName("deleteReason");

            builder.Property(x => x.DeleteTime).HasColumnName("deleteTime").HasColumnType("datetime");
        }
    }
}
