using AutoMapper;
using loja_api.application.Mapper.User;
using loja_api.application.Queries.User;
using loja_api.domain.Interfaces.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace loja_api.application.Queries.Handlers.User;

public class GetUserFilterHandlers : IRequestHandler<GetUserFilter, IEnumerable<UserDTO>>
{
    private readonly IUserRepositoryQueries _queries;

    private readonly IMapper _mapper;

    public GetUserFilterHandlers(IMapper mapper, IUserRepositoryQueries queries)
    {
        _queries = queries;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> Handle(GetUserFilter request, CancellationToken cancellationToken)
    {
        //Passa todos os valores do filtro para o Filter
        var filter = request.Filter;

        //Pega o Page para verificar se o valor é valido
        var page = filter.Page;

        //se o valor for menor que um substitui para um 
        if (page < 1)
            page = 1;

        //Multiplica por 10 para que seja possivel pegar todos da pagina
        page = page * 10;

        //Passa o valor de queries do user
        var queries = _queries.UserQuerable(); 

        if(!string.IsNullOrEmpty(filter.Cpf))
        {
            queries = queries.Where(c => c.Cpf == filter.Cpf);
        }
        if (!string.IsNullOrEmpty(filter.Cep))
        {
            queries = queries.Where(c => c.Cpf == filter.Cpf);
        }
        if (!string.IsNullOrEmpty(filter.Email))
        {
            queries = queries.Where(c => c.Email.ToLower().Contains(filter.Email.ToLower()));
        }
        if(!string.IsNullOrEmpty(filter.Name))
        {
            queries = queries.Where(c => c.Name.ToLower().Contains(filter.Name.ToLower()));
        }
        if (!string.IsNullOrEmpty(filter.Surname))
        {
            queries = queries.Where(c => c.Surname.ToLower().Contains(filter.Surname.ToLower()));
        }

        var Users = await _queries.UserFilterAsync(queries, page);

        return _mapper.Map<IEnumerable<UserDTO>>(Users);
    }
}
