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

            var optionsBuilder = new DbContextOptionsBuilder<ContextDB>();
            

            optionsBuilder.UseSqlServer("Server=localhost,8002;Database=WEBAPI;User Id=sa;Password=P@ssw0rd!;TrustServerCertificate=True;");

            return new ContextDB(optionsBuilder.Options);
        }
    }
}
