using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using loja_api.application.Models;
using Microsoft.Extensions.Options;
using loja_api.application.Interfaces;

namespace loja_api.application.Services;

public class JwtService : IJwtService
{
    private readonly JwtSettings _configuration;

    public JwtService(IOptions<JwtSettings> configuration)
    {
        _configuration = configuration.Value;
        //configuração para acessar informaçoes do appsetings
    }

    // Método que gera o token JWT
    public string GerarTokenLogin(string email, string? employee)
    {

        var chaveScreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key));
        //busca a chave secreta que esta no appsetings 

        var credentials = new SigningCredentials(chaveScreta, SecurityAlgorithms.HmacSha256);
        //informa a chave o tipo de segurança para a criação do Header do JWT

        var claims = new[]
        {
                new Claim("login", email),
                new Claim("Cargo", employee ?? "User")
                          
                //adiciona no claim o nome do gerador do token
            };

        var token = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                //Audience e o Issuer são assinaturas para que o Jwt funcione corretamente
                claims: claims,
                //claims serve para passar dados adicionais do gerador do código
                expires: DateTime.Now.AddHours(Convert.ToInt16(_configuration.ExpireHours)),
                //Define quantas horas o token vai existir
                signingCredentials: credentials
                );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
