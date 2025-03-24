using AutoMapper;
using loja_api.application.Interfaces;
using loja_api.domain.Interfaces;

namespace loja_api.application.Services;

public class GenericService<TDTO, TEntity> : IGenericService<TDTO, TEntity> where TEntity : class
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public GenericService(IRepository<TEntity> repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TDTO> GetByIdAsync(object id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TDTO>(entity);
    }//Buscar a Entidade pelo Id passado e gera um TDO da entidade

    public async Task AddAsync(TDTO dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _repository.AddAsync(entity);
    }//Transforma a EntidadeDTO em Entidade e chama o repositorio para Adicionar no banco de dados 

    public async Task UpdateAsync(TDTO dto)
    {

        var entity = _mapper.Map<TEntity>(dto);
        await _repository.UpdateAsync(entity);
    }//Transforma a EntidadeDTO em Entidade e chama o repositorio para Adicionar as Mudanças

    public async Task DeleteAsync(object id)
    {
        await _repository.DeleteAsync(id);
    }//Pega o Id passado e repassa para o DeleteAsync das entidades
}