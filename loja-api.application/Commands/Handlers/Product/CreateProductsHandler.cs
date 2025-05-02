using AutoMapper;
using loja_api.application.Commands.Product;
using loja_api.application.Interfaces;
using loja_api.domain.Entities;
using loja_api.domain.Interfaces.products;
using MediatR;

namespace loja_api.application.Commands.Handlers.Product;

public class CreateProductsHandler : IRequestHandler<CreateProductsCommands, bool>
{
    private readonly IProductsRepositoryCommands _productsRepositoryCommands;

    private readonly IMapper _mapper;

    private readonly IImageService _imageService;

    public CreateProductsHandler(IProductsRepositoryCommands productsRepositoryCommands, IMapper mapper, IImageService imageService)
    {
        _productsRepositoryCommands = productsRepositoryCommands;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<bool> Handle(CreateProductsCommands request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Products>(request.productsCreateDTO);

        if (request.productsCreateDTO.Images.Count() != 0)
        {
            //Transforma As string base64 em Strings da AzureStorage
            product.Images = await _imageService.UploadBase64ImagesAsync(request.productsCreateDTO.IdProducts, request.productsCreateDTO.Images);

        }

        //Adiciona a data que foi o produto foi criado
        product.Auditable.CreateDate = DateTime.UtcNow;

        //Adiciona no banco de dados
        await _productsRepositoryCommands.CreateProductsAsync(product);

        //Retorna no modelo de ProductsDTO para mostrar apenas o Necessario para o front
        return true;
    }
}
