using loja_api.application.Models;
using loja_api.ioc;
using MercadoPago.Config;

var builder = WebApplication.CreateBuilder(args);

//Conexão com o MercadoPago
MercadoPagoConfig.AccessToken = builder.Configuration["MercadoPago:AccessKey"];

//Passa os valores do JWT para uma classe dentro do Application para ser criado um Jwt
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

//Passa os valores do Azure Storage para a classe dentro do Application
builder.Services.Configure<BlobSettings>(builder.Configuration.GetSection("AzureBlob"));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

//Adiciona as configuraçoes do swagger 
builder.Services.AddSwagger();

//Conexão com o Banco de dados
builder.Services.AddInfra(builder.Configuration);

builder.Services.AddServices();

//Passa os valores do mediator
builder.Services.AddMediator();

builder.Services.AddAutoMapper();

builder.Services.AddInterfaces();

builder.Services.AddControllers();

builder.Services.AddAuth();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.Run();