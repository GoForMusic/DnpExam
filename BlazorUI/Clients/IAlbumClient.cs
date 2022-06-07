using Entities;

namespace BlazorUI.Clients;

public interface IAlbumClient
{
    public Task<Album> CreateAlbumAsync(Album album);
}