using System;
using HmsnoorBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HmsnoorBackend.Data.Configurations;

public class TransactionSalesItemConfiguration : IEntityTypeConfiguration<TransactionSalesItem>
{
    public void Configure(EntityTypeBuilder<TransactionSalesItem> builder)
    {
        builder.ToTable("TransactionSalesItem");
        builder.HasKey(e => new { e.InvoiceNo, e.ItemNo });

        builder.Property(e => e.InvoiceNo)
            .HasColumnName("InvoiceNo")
            .HasColumnType("nvarchar(20)")
            .HasMaxLength(20);

        builder.Property(e => e.ItemNo)
            .HasColumnName("ItemNo")
            .HasColumnType("nvarchar(20)")
            .HasMaxLength(20);

        builder.Property(e => e.ItemName)
            .HasColumnName("ItemName")
            .HasColumnType("nvarchar(max)");

        builder.Property(e => e.Price)
            .HasColumnName("Price")
            .HasColumnType("money");

        builder.Property(e => e.Quantity)
            .HasColumnName("Quantity")
            .HasColumnType("money");

        builder.Property(e => e.Amount)
            .HasColumnName("Amount")
            .HasColumnType("money");

    }
}
