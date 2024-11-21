using HmsnoorBackend.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HmsnoorBackend.Data.Configurations;

public class ItemCategoryConfiguration :
                        IEntityTypeConfiguration<ItemCategory>
{
    public void Configure(EntityTypeBuilder<ItemCategory> builder)
    {
        builder.ToTable("ItemCategory");
        builder.HasKey(e => e.ItemCategoryId);

        builder.Property(e => e.ItemCategoryId)
            .HasColumnName("ItemCategoryId")
            .HasColumnType("nvarchar(10)")
            .IsRequired();

        builder.Property(e => e.ItemCategoryName)
       .HasColumnName("ItemCategory")
       .HasColumnType("nvarchar(500)");


        builder.Property(e => e.ItemType)
            .HasColumnName("ItemType")
            .HasColumnType("nvarchar(500)");

    }
}
