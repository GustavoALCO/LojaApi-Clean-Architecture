using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.Cupom;

public interface ICupomRepositoryCommands 
{
    public Task CreateCupomAsync(Entities.Cupom cupom);

    public Task UpdateCupomAsync(Entities.Cupom cupom);
}
