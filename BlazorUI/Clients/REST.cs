using System.Text;
using System.Text.Json;

namespace BlazorUI.Clients;

public enum Operation
{
    Get,
    Post,
    Delete,
    Patch
}

public class REST
{
    private static string host = "http://localhost:5124";
    
    public static T GetDeserialized<T>(string jsonFormat) {
        T obj = JsonSerializer.Deserialize<T>(jsonFormat, new JsonSerializerOptions() {
            PropertyNameCaseInsensitive = true
        }) !;
        return obj;
    }
    
      public static async Task<string> callEndpoint(Operation methods,string endpoint, Object element=null)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Add("Authentification","abc123");
        HttpResponseMessage? response = new();
        string? content=String.Empty;
        StringContent? stringContent;
        
        switch (methods)
        {
            case Operation.Get:
                response = await client.GetAsync(host+endpoint);
                content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    Console.Write(content);
                    throw new Exception($"{content}");
                }

                break;
            case Operation.Post:
                stringContent = new(JsonSerializer.Serialize(element, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }), Encoding.UTF8, "application/json");
                response = await client.PostAsync(host + endpoint, stringContent);
                content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error: {response.StatusCode}, {content}");
                }
                break;
            case Operation.Delete:
                response = await client.DeleteAsync(host+endpoint);
                content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error: {response.StatusCode}, {content}");
                }
                break;
            case Operation.Patch:
                stringContent = new(JsonSerializer.Serialize(element, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }), Encoding.UTF8, "application/json");
                response = await client.PatchAsync(host + endpoint, stringContent);
                content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error: {response.StatusCode}, {content}");
                }
                break;
        }

        return content;
    }
}