namespace loja_api.application.Mapper.User;

public class UserUpdateDTO
{
    public required Guid IdUser { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Cep { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

}
