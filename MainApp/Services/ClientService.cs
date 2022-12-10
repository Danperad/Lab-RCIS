using LabsDB.Entity;
using MainApp.Repositories;

namespace MainApp.Services;

public class ClientService : IClientRepository
{
    private ApplicationContext _context;

    public ClientService(ApplicationContext context)
    {
        _context = context;
    }
    public IEnumerable<House> GetAllHouses()
    {
        throw new NotImplementedException();
    }
}