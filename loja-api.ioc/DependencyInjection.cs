using loja_api.infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace loja_api.ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContextDB>(o =>
        {
            o.UseSqlite(configuration.GetConnectionString("BdConnection"),
                m => m.MigrationsAssembly(typeof(ContextDB).Assembly.FullName));
        });

        // Necessário para a criação de migrações no ambiente de design
        services.AddScoped<DbContextOptions<ContextDB>>(provider =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextDB>();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("BdConnection"),
                m => m.MigrationsAssembly(typeof(ContextDB).Assembly.FullName));
            return optionsBuilder.Options;
        });

        return services;
    }
}
