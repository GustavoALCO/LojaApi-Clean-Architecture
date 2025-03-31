namespace loja_api.application.Interfaces.Auxiliar;

public interface IImageService
{
    Task<List<string>> UploadBase64ImagesAsync(Guid ID, List<string> base64Images);

    Task DeleteImagesAsync(List<string> imageNames);
}
