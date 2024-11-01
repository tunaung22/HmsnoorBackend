using System.Text.Json;
using HmsnoorBackend.Data;
using HmsnoorBackend.Repositories;
using HmsnoorBackend.Services;
using HmsnoorBackend.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace HmsnoorBackend;

public class Program
{
    public static void Main(string[] args)
    {
        // ========== Load .ENV ====================
        var dotenv = Path.Combine(Directory.GetCurrentDirectory(), ".env");
        DotEnv.Load(dotenv);

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
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
            });
        builder.Services.AddEndpointsApiExplorer();

        // ========== Setup DbContext ====================
        // Use Connection String Builder
        var connStringBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("HmsnoorDb"))
        {
            // Orders: 
            // 1. command-line args -> 2. enviroment variables -> 3. user secrets ->
            // 4. appsettings.{Environment}.json -> 5. appsettings.json -> 
            // 6. build-in config providers -> 7. custom config
            InitialCatalog = builder.Configuration["DB_NAME"],
            UserID = builder.Configuration["DB_USER"],
            Password = builder.Configuration["DB_PASSWORD"]
        };
        // DbContext
        builder.Services.AddDbContext<HmsnoorDbContext>(options =>
        {
            options.UseSqlServer(connStringBuilder.ConnectionString);
            // .LogTo(Console.WriteLine, LogLevel.Information);
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
