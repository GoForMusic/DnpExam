using Entities;

namespace BlazorUI.Clients;

public class DisplayRestClient : IDisplayClient
{
    public async Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic)
    {
        try
        {
            var content = await REST.callEndpoint(Operation.Get,$"/images?albumCreator={albumCreator}&topic={topic}");
            return REST.GetDeserialized<ICollection<Image>>(content);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}