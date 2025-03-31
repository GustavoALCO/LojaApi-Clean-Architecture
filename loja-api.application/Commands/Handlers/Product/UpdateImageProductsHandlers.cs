using loja_api.application.Commands.Product;
using loja_api.application.Interfaces.Auxiliar;
using loja_api.application.Queries.Product;
using loja_api.domain.Interfaces.products;
using MediatR;

namespace loja_api.application.Commands.Handlers.Product;

public class UpdateImageProductsHandlers : IRequestHandler<UpdateImageProductsCommands, string>
{

    private readonly IProductsQueryRepository _query;

    private readonly IImageService _imageService;

    public UpdateImageProductsHandlers(IImageService imageService, IProductsQueryRepository query)
    {
        _imageService = imageService;
        _query = query;
    }

    public async Task<string> Handle(UpdateImageProductsCommands request, CancellationToken cancellationToken)
    {
        var products = await _query.GetProductsIDAsync(request.Id);

        if (products == null)
            throw new Exception("Não encontrado Produto com esse ID");

        await _imageService.DeleteImagesAsync(products.Images);

        await _imageService.UploadBase64ImagesAsync(products.IdProducts, request.Images);

        return "Imagens Substituidas";
    }
}
