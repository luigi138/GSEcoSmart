using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EcoSmart.Persistencia
{
    public class EcoSmartDbContextFactory : IDesignTimeDbContextFactory<EcoSmartDbContext>
    {
        public EcoSmartDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EcoSmartDbContext>();
            optionsBuilder.UseOracle(configuration.GetConnectionString("OracleFIAP"));

            return new EcoSmartDbContext(optionsBuilder.Options);
        }
    }
}
