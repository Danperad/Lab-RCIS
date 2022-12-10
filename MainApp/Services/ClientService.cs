using LabsDB.Entity;
using MainApp.Repositories;
using Microsoft.EntityFrameworkCore;

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
        return _context.Houses.Include(h => h.Indications);
    }
}