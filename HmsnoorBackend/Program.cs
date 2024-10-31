using HmsnoorBackend.Data;
using HmsnoorBackend.Repositories;
using HmsnoorBackend.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HmsnoorBackend;

public class Program
{
    public static void Main(string[] args)
    {
        // ========== Serilog ====================
        var log = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        Log.Logger = log;

        // ========== Builder ====================
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // builder.Services.AddControllersWithViews();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        // ========== DbContext ====================
        // builder.Services.AddDbContext<HmsnoorDbContext>(options => 
        //     options.UseSqlServer(
        //              builder.Configuration.GetConnectionString("HmsnoorDb"))
        // );

        // Use Connection String Builder
        var connStringBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("HmsnoorDb"));
        connStringBuilder.UserID = builder.Configuration["DBUser"];
        connStringBuilder.Password = builder.Configuration["DBPassword"];

        builder.Services.AddDbContext<HmsnoorDbContext>(options =>
        {
            options.UseSqlServer(connStringBuilder.ConnectionString);
        });


        // ========== Register services and repositories ====================
        // Repository Layer
        builder.Services.AddScoped<IItemHeaderRepository, ItemHeaderRepository>();
        builder.Services.AddScoped<ITransactionSaleRepository, TransactionSaleRepository>();
        builder.Services.AddScoped<ITransactionSalesItemRepository, TransactionSalesItemRepository>();
        // Service Layer
        builder.Services.AddScoped<ItemHeaderService>();
        builder.Services.AddScoped<TransactionSalesService>();
        builder.Services.AddScoped<TransactionSalesItemService>();

        // builder.Logging.AddJsonConsole();


        var app = builder.Build();

        // ========== Configure the HTTP request pipeline. ====================
        if (!app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            // app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
            // app.useswagger
            // app.useswaggerui
        }


        // ========== Staticfiles ====================
        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        // app.MapControllerRoute(
        //     name: "default",
        //     pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllers();

        app.Run();
    }
}
