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
    public IEnumerable<House> GetAllHouses()
    {
        throw new NotImplementedException();
    }
}