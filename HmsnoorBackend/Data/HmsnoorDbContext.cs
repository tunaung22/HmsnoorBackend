using HmsnoorBackend.Data.Configurations;
using HmsnoorBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HmsnoorBackend.Data;

public class HmsnoorDbContext : DbContext
{
    public HmsnoorDbContext(DbContextOptions<HmsnoorDbContext> options) : base(options)
    { }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer("YourConnectionStringHere");
    // }


    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<Currency> Currency { get; set; }
    public DbSet<ItemCategory> ItemCategory { get; set; }
    public DbSet<ItemHeader> ItemHeaders { get; set; }
    public DbSet<ItemDetail> ItemDetail { get; set; }
    public DbSet<TransactionSale> TransactionSales { get; set; }
    public DbSet<TransactionSalesItem> TransactionSalesItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // https://learn.microsoft.com/en-us/ef/core/modeling/#grouping-configuration
        // method 1
        // new ItemHeaderConfiguration().Configure(builder.Entity<ItemHeader>());
        // method 2
        // builder.ApplyConfiguration(new ItemHeaderConfiguration());

        builder.ApplyConfiguration(new UserGroupConfiguration());
        builder.ApplyConfiguration(new UserAccountConfiguration());
        builder.ApplyConfiguration(new CurrencyConfiguration());
        builder.ApplyConfiguration(new ItemCategoryConfiguration());
        builder.ApplyConfiguration(new ItemHeaderConfiguration());
        builder.ApplyConfiguration(new ItemDetailConfiguration());
        builder.ApplyConfiguration(new TransactionSaleConfiguration());
        builder.ApplyConfiguration(new TransactionSalesItemConfiguration());

    }

}
