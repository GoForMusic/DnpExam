using Entities;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace BlazorUI.Clients;

public class AlbumRestClient : IAlbumClient
{
    public async Task<Album> CreateAlbumAsync(Album album)
    {
        try
        {
            var content = await REST.callEndpoint(Operation.Post,"/albums",album);
            return REST.GetDeserialized<Album>(content);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}