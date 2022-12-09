using LabsDB.Entity;
using MainApp.Interfaces;

namespace Tests.Services;

public class TestClientService : IClientService
{
    public IEnumerable<House> GetAllHouses()
    {
        return Enumerable.Range(0, 2).Select(_ => new House());
    }
}