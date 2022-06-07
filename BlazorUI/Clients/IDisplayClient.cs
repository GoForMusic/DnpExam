using Entities;

namespace BlazorUI.Clients;

public interface IDisplayClient
{
    public Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic);
}