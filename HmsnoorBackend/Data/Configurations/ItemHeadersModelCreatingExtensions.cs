using HmsnoorBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Data.Configurations;


// Usage at db context onModelCreating:
// protected override void OnModelCreating(ModelBuilder builder)
// {
//     builder.ConfigureItemHeaders();
// }

public static class ItemHeadersModelCreatingExtensions
{
    public static void ConfigureItemHeaders(this ModelBuilder builder)
    {
        builder.Entity<ItemHeader>(b =>
        {
            b.ToTable("ItemHeader");
            b.HasKey(e => new { e.ItemNo, e.ItemType });

            b.Property(e => e.ItemNo)
                .HasColumnName("ItemNo")
                .HasMaxLength(10);

            b.Property(e => e.ItemName)
                .HasColumnName("ItemName")
                .HasMaxLength(200);

            b.Property(e => e.ItemType)
                .HasColumnName("ItemType")
                .HasMaxLength(100);

            b.Property(e => e.ItemCategory)
                .HasColumnName("ItemCategory")
                .HasMaxLength(500);

            b.Property(e => e.MItemName)
                .HasColumnName("MItemName")
                .HasMaxLength(500);
        });
    }
}
