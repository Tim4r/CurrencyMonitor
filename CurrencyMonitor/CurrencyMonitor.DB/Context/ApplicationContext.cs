using CurrencyMonitor.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CurrencyMonitor.DB.Context;

public class ApplicationContext : DbContext
{
    public DbSet<CurrencyRates> CurrencyRates { get; set; }

    IConfiguration? _configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = _configuration.GetConnectionString("MyConnectionString");
        optionsBuilder.UseSqlServer($@"{connectionString}");
    }
}
