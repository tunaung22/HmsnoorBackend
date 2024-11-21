using Castle.Core.Configuration;
using HmsnoorBackend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HmsnoorBackend.UnitTests;

public class TestDatabaseFixture : IDisposable
{
    // private readonly HmsnoorDbContext _context;

    public TestDatabaseFixture()
    {
        // var options = new DbContextOptionsBuilder<HmsnoorDbContext>()
        //     .UseSqlServer("Server=127.0.0.1,1433;Database=hmsNoorTest;UserId=sa;Password=P@ssw0rd;Encrypt=False;TrustServerCertificate=True;")
        //     .Options;
        // _context = new HmsnoorDbContext(options);
        // _context.Database.EnsureDeleted();
        // _context.Database.Migrate();



        // var configuration = new ConfigurationBuilder()
        //     .SetBasePath(Directory.GetCurrentDirectory())
        //     .AddJsonFile("appsettings.testing.json")
        //     .Build();

        // var services = new ServiceCollection();
        // services.AddDbContext<HmsnoorDbContext>(options =>
        // {
        //     options.UseSqlServer(configuration.GetConnectionString("hmsNoor"));
        // });
    }

    public void Dispose()
    {
        // _context.Database.EnsureDeleted();
        // _context.Dispose();
    }
}