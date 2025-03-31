using Azure.Storage.Blobs;
using loja_api.application.Interfaces.Auxiliar;
using loja_api.application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace loja_api.application.Services;

public class ImageService : IImageService
{

    private readonly BlobSettings _blobService;

    public ImageService(IOptions<BlobSettings> configuration )
    {
        _blobService = configuration.Value;


    }

    public async Task<List<string>> UploadBase64ImagesAsync(Guid ID, List<string> base64Images)
    {
        List<string> imageUrls = new List<string>();

        foreach (var base64Image in base64Images)
        {
            var fileName = $"{ID.ToString()}&{Guid.NewGuid().ToString()}.jpg";
            // Gera um nome único para a imagem

            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");
            // Remove a parte desnecessária do base64

            byte[] imageBytes = Convert.FromBase64String(data);
            // Converte a string base64 em um array de bytes

            var blobClient = new BlobClient(_blobService.ConnectionString, _blobService.Container, fileName);
            // Cria um cliente para o Blob Storage

            // Envia a imagem para o Storage de forma assíncrona
            using (var stream = new MemoryStream(imageBytes))
            {
                await blobClient.UploadAsync(stream);
            }

            imageUrls.Add(blobClient.Uri.AbsoluteUri); // Adiciona a URL da imagem à lista
        }

        return imageUrls;
        // Retorna a lista de URLs das imagens
    }

    public async Task DeleteImagesAsync(List<string> imageNames)
    {
        var containerClient = new BlobContainerClient(_blobService.ConnectionString, _blobService.Container);
        //Conecta no blob passando o nome do container

        foreach (var UrlImage in imageNames)
        {//Faz um loop com a quantidade de itens que existe dentro da list

            var imageName = GetBlobNameFromUrl(UrlImage);
            //Separa apenas o id da imagem para ser apagada 

            var blobClient = containerClient.GetBlobClient(imageName);
            //Passa o Id da imagem a ser excluida

            if (await blobClient.ExistsAsync())
            {
                await blobClient.DeleteAsync();
                Console.WriteLine($"Imagem {imageName} deletada com sucesso.");
            }//Se acha ele direciona para o deleteAsync onnde vai ser apagado
            else
            {
                Console.WriteLine($"Imagem {imageName} não encontrada.");
            }//Se não achar ele envia uma mensagem no console informando que não foi achado
        }
    }

    private string GetBlobNameFromUrl(string url)
    {
        Uri uri = new Uri(url);
        return Path.GetFileName(uri.LocalPath);
    }
}
