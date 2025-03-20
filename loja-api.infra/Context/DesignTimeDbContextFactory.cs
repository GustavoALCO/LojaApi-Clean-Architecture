using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace loja_api.infra.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ContextDB>
    {
        public ContextDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextDB>();

            // Carregar o arquivo de configuração (appsettings.json)
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  // Certifique-se de usar o caminho correto
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)  // Arquivo obrigatorio
                .Build();

            optionsBuilder.UseSqlite(configuration.GetConnectionString("BdConnection"),
                m => m.MigrationsAssembly(typeof(ContextDB).Assembly.FullName));

            return new ContextDB(optionsBuilder.Options);
        }
    }
}
