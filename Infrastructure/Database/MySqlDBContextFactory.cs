using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class MySqlDBContextFactory : IDesignTimeDbContextFactory<MySqlDBContext>
{
    public MySqlDBContext CreateDbContext(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        // Set the base path to the directory where appsettings.json is located
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\Core.Platform");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("CorePlatformConnectionString");

        var optionsBuilder = new DbContextOptionsBuilder<MySqlDBContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new MySqlDBContext(optionsBuilder.Options);
    }
}