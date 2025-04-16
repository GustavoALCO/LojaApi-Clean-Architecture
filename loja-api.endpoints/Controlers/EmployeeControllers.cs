using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace loja_api.endpoints.Controlers;

public class EmployeeControllers : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    //Chamar todas as operaçoes dos Mediators e priar um endpoints para eles 
}
