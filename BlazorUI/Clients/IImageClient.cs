using Entities;

namespace BlazorUI.Clients;

public interface IImageClient
{
    public Task AddImageToAlbumAsync(Image image, string albumTitle);
    public Task<ICollection<string>> GetAlbumTitlesAsync();
}