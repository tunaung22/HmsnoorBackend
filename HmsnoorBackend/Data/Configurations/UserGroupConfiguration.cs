using HmsnoorBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HmsnoorBackend.Data;

public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.ToTable("UserGroup");
        builder.HasKey(e => e.UserGroupName);

        builder.Property(e => e.UserGroupName)
            .HasColumnName("UserGroupName")
            .HasColumnType("nvarchar(20)")
            .HasMaxLength(20);

        builder.Property(e => e.Description)
            .HasColumnName("Description")
            .HasColumnType("nvarchar(MAX)")
            .HasMaxLength(20);

        builder.Property(e => e.Inactive)
            .HasColumnName("InActive")
            .HasColumnType("bit");

        builder.Property(e => e.CreateUserId)
            .HasColumnName("CreateUserId")
            .HasColumnType("int");

        builder.Property(e => e.ModifyUserId)
            .HasColumnName("ModifyUserId")
            .HasColumnType("int");

        builder.Property(e => e.CreateUserDate)
            .HasColumnName("CreateUserDate")
            .HasColumnType("datetime");

        builder.Property(e => e.ModifyUserDate)
            .HasColumnName("ModifyUserDate")
            .HasColumnType("datetime");

        builder.Property(e => e.Fo)
            .HasColumnName("FO")
            .HasColumnType("bit");

        builder.Property(e => e.SaleService)
            .HasColumnName("SaleService")
            .HasColumnType("bit");

        builder.Property(e => e.Restaurant)
            .HasColumnName("Restaurant")
            .HasColumnType("bit");

        builder.Property(e => e.Account)
            .HasColumnName("Account")
            .HasColumnType("bit");

        builder.Property(e => e.Setup)
            .HasColumnName("Setup")
            .HasColumnType("bit");

        builder.Property(e => e.UserAdmin)
            .HasColumnName("UserAdmin")
            .HasColumnType("bit");

        builder.Property(e => e.Setting)
            .HasColumnName("Setting")
            .HasColumnType("bit");

        builder.Property(e => e.Store)
            .HasColumnName("Store")
            .HasColumnType("bit");

    }
}
