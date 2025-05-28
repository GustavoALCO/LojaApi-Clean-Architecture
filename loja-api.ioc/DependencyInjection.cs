using loja_api.infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;
using loja_api.domain.Interfaces.products;
using loja_api.infra.Repositories.Product;
using loja_api.application.Services;
using loja_api.domain.Interfaces.Storage;
using loja_api.infra.Repositories.Storages;
using loja_api.infra.Repositories.Storage;
using loja_api.domain.Interfaces.Users;
using loja_api.infra.Repositories.Users;
using loja_api.domain.Interfaces.Paymants;
using loja_api.infra.Repositories.Paymant;
using loja_api.domain.Interfaces.Employee;
using loja_api.infra.Repositories.Employee;
using loja_api.domain.Interfaces.Cupom;
using loja_api.infra.Repositories.Cupom;
using loja_api.application.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace loja_api.ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContextDB>(o =>
        {
            o.UseSqlServer("Server=Dbserver;Database=WEBAPI;User Id=sa;Password=P@ssw0rd!;TrustServerCertificate=true;",
                m => m.MigrationsAssembly(typeof(ContextDB).Assembly.FullName));
        });

        return services;
    }//Cria uma ServiceCollection para uma conexão com o banco de dados 

    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) 
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "MeuBackEnd",
                    ValidAudience = "MeuFrontEnd",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("69f6ab5d-904b-4793-af49-a3dc0a1b1412"))
                };
            });

        services.AddAuthorization();

        return services;
    }


    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
                                    {
                                    
                                    
                                        c.SwaggerDoc("v1", new OpenApiInfo
                                        {
                                            Title = "Loja - API",
                                            Version = "v1"
                                        });
                                    
                                        // Configuração do JWT no Swagger
                                        var securitySchema = new OpenApiSecurityScheme
                                        {
                                            Name = "Jwt Authentication",
                                            Description = "Entre com o JWT Bearer",
                                            In = ParameterLocation.Header,
                                            Type = SecuritySchemeType.Http,
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
    }
    //Cria uma ServiceCollection do Swagger para Organizar melhor o Program do Endpoints

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
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IUpdateStorage, UpdateStorage>();

        return services;
    }//Declara Todos os Services

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(ctg => ctg.RegisterServicesFromAssembly(Assembly.Load("loja-api.application")));

        return services;
    }

    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }

    public static IServiceCollection AddInterfaces(this IServiceCollection services)
    {
        services.AddScoped<IProductsQueryRepository, ProductsRepositoryQueries>();
        services.AddScoped<IProductsRepositoryCommands, ProductsRepositoryCommands>();
        services.AddScoped<IStorageRepositoryCommands, StorageRepositoryCommands>();
        services.AddScoped<IStorageRepositoryQueries, StorageRepositoryQueries>();
        services.AddScoped<IUserRepositoryCommands, UserRepositoryCommands>();
        services.AddScoped<IUserRepositoryQueries, UserRepositoryQuery>();
        services.AddScoped<IpaymantRepositotyQuery, PaymantRepositoryQuery>();
        services.AddScoped<IProductsRepositoryCommands, ProductsRepositoryCommands>();
        services.AddScoped<IpaymantRepositotyQuery, PaymantRepositoryQuery>();
        services.AddScoped<IPaymantRepositoryCommands, PaymantRepositoryCommands>();
        services.AddScoped<IEmployeeRepositoryCommands, EmployeeRepositoryCommands>();
        services.AddScoped<IEmployeeRepositoryQuery, EmployeeRepositoryQueries>();
        services.AddScoped<ICupomRepositoryCommands, CupomRepositoryCommands>();
        services.AddScoped<ICupomRepositoryQuery, CupomRepositoryQuery>();

        return services;    
    }
}
