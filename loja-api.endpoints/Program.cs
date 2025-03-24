using loja_api.application.Models;
using loja_api.ioc;
using MercadoPago.Config;

var builder = WebApplication.CreateBuilder(args);

//Conexão com o MercadoPago
MercadoPagoConfig.AccessToken = builder.Configuration["MercadoPago:AccessKey"];

//Passa os valores do JWT para uma classe dentro do Application para ser criado um Jwt
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

//Adiciona as configuraçoes do swagger 
builder.Services.AddSwagger();

//Conexão com o Banco de dados
builder.Services.AddInfra(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();