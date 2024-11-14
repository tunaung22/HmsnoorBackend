using HmsnoorBackend.Data.Models;
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

        builder.Property(e => e.CurrencyDescription)
            .HasColumnName("CurrencyDescription")
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        builder.Property(e => e.CurrencyNotation)
            .HasColumnName("CurrencyNotation")
            .HasColumnType("nvarchar(3)");
    }
}
