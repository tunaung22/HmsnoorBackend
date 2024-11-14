using HmsnoorBackend.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HmsnoorBackend.Data.Configurations;

public class ItemDetailConfiguration : IEntityTypeConfiguration<ItemDetail>
{
    // https://learn.microsoft.com/en-us/ef/core/modeling/#grouping-configuration

    public void Configure(EntityTypeBuilder<ItemDetail> builder)
    {
        builder.ToTable("ItemDetail");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Price)
            .HasColumnName("Price")
            .HasColumnType("money")
            .IsRequired();

        builder.Property(e => e.ItemNo)
            .HasColumnName("ItemNo")
            .HasColumnType("nvarchar(10)")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.ItemType)
            .HasColumnName("ItemType")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.CurrencyId)
            .HasColumnName("CurrencyId")
            .HasColumnType("int(4)")
            .IsRequired();

    }
}
