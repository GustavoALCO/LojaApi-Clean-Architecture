namespace loja_api.application.Interfaces.Auxiliar;

public interface IHashService
{
    string CreateHash(object user, string password);
    bool ValidatePassword(object user, string hashedPassword, string providedPassword);
}
