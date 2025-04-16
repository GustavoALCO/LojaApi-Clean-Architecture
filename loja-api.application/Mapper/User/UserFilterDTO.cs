namespace loja_api.application.Mapper.User;

public class UserFilterDTO
{

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Cpf { get; set; }

    public string Cep { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public int Page {  get; set; }
}
