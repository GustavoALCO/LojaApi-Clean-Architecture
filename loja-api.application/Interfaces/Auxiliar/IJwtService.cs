namespace loja_api.application.Interfaces.Auxiliar;

public interface IJwtService
{
    string GerarTokenLogin(string email, string? employee);
}
