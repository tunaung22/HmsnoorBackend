using System;
using HmsnoorBackend.Data.Configurations;
using HmsnoorBackend.Models;
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

    public DbSet<ItemHeader> ItemHeaders { get; set; }
    public DbSet<TransactionSale> TransactionSales { get; set; }
    public DbSet<TransactionSalesItem> TransactionSalesItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.ApplyConfiguration(new ItemHeaderConfiguration());
        builder.ApplyConfiguration(new TransactionSaleConfiguration());
        builder.ApplyConfiguration(new TransactionSalesItemConfiguration());

    }

}
