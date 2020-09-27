using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PaninApi.Infrastructure
{
    public class PaninApiDesignTimeDbContext : IDesignTimeDbContextFactory<PaninApiDbContext>
    {
        public PaninApiDbContext CreateDbContext(string[] args)
        {
            return new PaninApiDbContext(ConfigureOptions());
        }

        private DbContextOptions<PaninApiDbContext> ConfigureOptions()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets(typeof(PaninApiDbContext).Assembly);

            var configuration = configurationBuilder.Build();

            var dbContextOptions = new DbContextOptionsBuilder<PaninApiDbContext>();
            dbContextOptions.UseNpgsql(configuration.GetConnectionString("default"));

            return dbContextOptions.Options;
        }
    }
}