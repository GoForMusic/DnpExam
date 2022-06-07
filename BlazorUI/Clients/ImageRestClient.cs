using Entities;

namespace BlazorUI.Clients;

public class ImageRestClient : IImageClient
{
    public async Task AddImageToAlbumAsync(Image image, string albumTitle)
    {
        try
        {
            var content = await REST.callEndpoint(Operation.Post,$"/albums/image/{albumTitle}",image);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ICollection<string>> GetAlbumTitlesAsync()
    {
        try
        {
            var content = await REST.callEndpoint(Operation.Get,$"/albums/titles");
            return REST.GetDeserialized<ICollection<string>>(content);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}