using HmsnoorBackend.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HmsnoorBackend.Data.Configurations;

public class ItemHeaderConfiguration : IEntityTypeConfiguration<ItemHeader>
{
    // https://learn.microsoft.com/en-us/ef/core/modeling/#grouping-configuration

    public void Configure(EntityTypeBuilder<ItemHeader> builder)
    {
        builder.ToTable("ItemHeader");
        builder.HasKey(e => new { e.ItemNo, e.ItemType });

        builder.Property(e => e.ItemNo)
            .HasColumnName("ItemNo")
            .HasMaxLength(10);

        builder.Property(e => e.ItemName)
            .HasColumnName("ItemName")
            .HasMaxLength(200);

        builder.Property(e => e.ItemType)
            .HasColumnName("ItemType")
            .HasMaxLength(100);

        builder.Property(e => e.ItemCategory)
            .HasColumnName("ItemCategory")
            .HasMaxLength(500);

        builder.Property(e => e.MItemName)
            .HasColumnName("MItemName")
            .HasMaxLength(500);

    }

}
