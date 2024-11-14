using HmsnoorBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HmsnoorBackend.Data.Configurations;

public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable("UserAccount");
        builder.HasKey(e => e.UserId);

        builder.Property(e => e.UserName)
            .HasColumnName("UserName")
            .HasColumnType("nvarchar(50)")
            .HasMaxLength(50);

        builder.Property(e => e.Password)
            .HasColumnName("Password")
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.UserGroup)
            .HasColumnName("UserGroup")
            .HasColumnType("nvarchar(20)")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.Remark)
            .HasColumnName("Remark")
            .HasColumnType("nvarchar(MAX)");

        builder.Property(e => e.IsInsert)
            .HasColumnName("isInsert")
            .HasColumnType("bit");

        builder.Property(e => e.IsUpdate)
            .HasColumnName("isUpdate")
            .HasColumnType("bit");

        builder.Property(e => e.IsDelete)
            .HasColumnName("isDelete")
            .HasColumnType("bit");

        builder.Property(e => e.Inactive)
            .HasColumnName("InaActive")
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
    }
}
