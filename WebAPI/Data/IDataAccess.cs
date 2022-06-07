using Entities;

namespace WebAPI.Data;

public interface IDataAccess
{
    public Task<Album> AddAlbumAsync(Album album);
    public Task<ICollection<string>> GetAlbumTitlesAsync();
    public Task AddImage(Image img, string albumTitle);
    public Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic);
}