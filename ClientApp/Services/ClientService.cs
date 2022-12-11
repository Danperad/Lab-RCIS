using System.Text.Json;
using ClientApp.Repositories;
using LabsDB.Entity;

namespace ClientApp.Services;

public class ClientService : IClientRepository
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<House>> GetAllHouses()
    {
        var client = _httpClientFactory.CreateClient();
        try
        {
            var responseMessage = await client.GetAsync("http://localhost:5174/client/get");
            if (!responseMessage.IsSuccessStatusCode) 
                return Enumerable.Empty<House>();
            
            var str = await responseMessage.Content.ReadAsStringAsync();
            var res = JsonSerializer.Deserialize<List<House>>(str);
            return res ?? Enumerable.Empty<House>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Enumerable.Empty<House>();
        }
    }
}