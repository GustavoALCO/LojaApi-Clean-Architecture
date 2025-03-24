namespace loja_api.application.Interfaces;

public interface IJwtService
{
     string GerarTokenLogin(string email, string? employee);
}
