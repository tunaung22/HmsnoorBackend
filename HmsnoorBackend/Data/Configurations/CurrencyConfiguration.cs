using System;
using HmsnoorBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HmsnoorBackend.Data.Configurations;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("Currency");
        builder.HasKey(e => e.CurrencyId);

        builder.Property(e => e.CurrencyId)
            .HasColumnName("CurrencyId")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(e => e.CurrencyName)
            .HasColumnName("CurrencyName")
            .HasColumnType("nvarchar(100)")
            .IsRequired();
    }
}
