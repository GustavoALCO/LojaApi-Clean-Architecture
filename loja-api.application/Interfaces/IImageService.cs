namespace loja_api.application.Interfaces;

public interface IImageService
{
    Task<List<string>> UploadBase64ImagesAsync(List<string> base64Images);

    Task DeleteImagesAsync(List<string> imageNames);
}
