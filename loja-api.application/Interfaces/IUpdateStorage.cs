namespace loja_api.application.Interfaces;

public interface IUpdateStorage
{
    public Task UpdateValuesStorage(Guid Id, int quantity); 

}
