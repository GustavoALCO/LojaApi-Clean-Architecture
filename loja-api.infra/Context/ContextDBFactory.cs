using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace loja_api.infra.Context
{
    public class ContextDBFactory : IDesignTimeDbContextFactory<ContextDB>
    {
        public ContextDB CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ContextDB>();
            var connectionString = configuration.GetConnectionString("DBString");

            optionsBuilder.UseSqlServer(connectionString);

            return new ContextDB(optionsBuilder.Options);
        }
    }
}
