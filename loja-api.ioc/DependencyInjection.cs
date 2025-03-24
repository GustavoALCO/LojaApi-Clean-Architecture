using loja_api.infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using loja_api.application.Interfaces;
using loja_api.application.Services;

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
    }//Cria uma ServiceCollection para uma conexão com o banco de dados 

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
        
        
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Loja Ferramentas- API"
                //Declara Um titulo para o Swagger
            });
        
            // Configuração do JWT no Swagger
            var securitySchema = new OpenApiSecurityScheme
            {
                Name = "Jwt Authentication",
                Description = "Entre com o JWT Bearer",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
        
            c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securitySchema, new string[] {} }
            });
        });

        return services;
    }//Cria uma ServiceCollection do Swagger para Organizar melhor o Program do Endpoints

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }//Cria uma ServiceCollection do AutoMapper para organizar o código

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMercadoPagoService, MercadoPagoService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IHashService, HashService>();
        services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

        return services;
    }//Declara Todos os Services


}