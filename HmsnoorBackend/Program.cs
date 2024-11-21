using System.Text.Json;
using HmsnoorBackend.Data;
using HmsnoorBackend.QueryRepositories.Interfaces;
using HmsnoorBackend.Middlewares;
using HmsnoorBackend.QueryRepositories;
using HmsnoorBackend.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using HmsnoorBackend.Repositories.Interfaces;
using HmsnoorBackend.Repositories;
using HmsnoorBackend.Services.Interfaces;
using HmsnoorBackend.Services;

namespace HmsnoorBackend;

public class Program
{
    public static void Main(string[] args)
    {
        // ========== Load .ENV ================================================
        var dotenv = Path.Combine(Directory.GetCurrentDirectory(), ".env");
        DotEnv.Load(dotenv);

        // ========== Serilog ==================================================
        var log = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        Log.Logger = log;

        // ========== Builder ==================================================
        var builder = WebApplication.CreateBuilder(args);

        // ========== Services =================================================
        // builder.Services.AddControllersWithViews();
        builder.Services.AddControllers()
            // https://learn.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-8.0
            .ConfigureApiBehaviorOptions(options =>
            {
                // Disable automatic creation of a ProblemDetails for error status codes
                // options.SuppressMapClientErrors = true; 
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

        // ========== Exception Handlers =======================================
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        // ========== OpenAPI ==================================================
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hmsnoor API", Version = "v1" });
        });

        // ========== Setup DbContext ==========================================
        var connStringBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("HmsnoorDb"))
        {
            // Orders: 
            // 1) command-line args -> 2) enviroment variables -> 3) user secrets ->
            // 4) appsettings.{Environment}.json -> 5) appsettings.json -> 
            // 6) build-in config providers -> 7) custom config
            InitialCatalog = builder.Configuration["DB_NAME"],
            UserID = builder.Configuration["DB_USER"],
            Password = builder.Configuration["DB_PASSWORD"]
        };
        builder.Services.AddDbContext<HmsnoorDbContext>(options =>
        {
            options.UseSqlServer(connStringBuilder.ConnectionString);
            // .LogTo(Console.WriteLine, LogLevel.Information);
        });


        // ========== Register services and repositories =======================
        // QueryRepository Layer
        builder.Services.AddScoped<IItemQueryRepository, ItemQueryRepository>();
        builder.Services.AddScoped<ISaleQueryRepository, SaleQueryReository>();
        // Repository Layer
        builder.Services.AddScoped<IUserGroupRepository, UserGroupRepository>();
        builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
        builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        builder.Services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
        builder.Services.AddScoped<IItemRepository, ItemRepository>();
        builder.Services.AddScoped<IItemDetailRepository, ItemDetailRepository>();
        builder.Services.AddScoped<ISaleInvoiceRepository, SaleInvoiceRepository>();
        builder.Services.AddScoped<ISaleItemRepository, SaleItemRepository>();
        // Service Layer
        builder.Services.AddScoped<IUserGroupService, UserGroupService>();
        builder.Services.AddScoped<IUserAccountService, UserAccountService>();
        builder.Services.AddScoped<ICurrencyService, CurrencyService>();
        builder.Services.AddScoped<IItemCategoryService, ItemCategoryService>();
        builder.Services.AddScoped<IItemService, ItemService>();
        builder.Services.AddScoped<ISaleInvoiceService, SaleInvoiceService>();
        builder.Services.AddScoped<ISaleItemService, SaleItemService>();
        // builder.Logging.AddJsonConsole();

        // ========== App ======================================================
        var app = builder.Build();

        // ========== Configure the HTTP request pipeline. =====================
        if (!app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            // app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

        }

        app.UseExceptionHandler();
        app.UseStatusCodePages();


        // ========== Staticfiles ==============================================
        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseRouting();

        // Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "HmsnoorAPI V1");
        });

        app.UseAuthorization();

        // app.MapControllerRoute(
        //     name: "default",
        //     pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllers();

        app.Run();
    }
}
