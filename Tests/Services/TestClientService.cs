using LabsDB.Entity;
using MainApp.Repositories;

namespace Tests.Services;

public class TestClientService : IClientRepository
{
    public IEnumerable<House> GetAllHouses()
    {
        return Enumerable.Range(0, 2).Select(_ => new House());
    }
}