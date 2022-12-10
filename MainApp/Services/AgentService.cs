using LabsDB.Entity;
using MainApp.Repositories;

namespace MainApp.Services;

public class AgentService : IAgentRepository
{
    private ApplicationContext _context;

    public AgentService(ApplicationContext context)
    {
        _context = context;
    }
    public bool AddNewIndication(Indication indication)
    {
        throw new NotImplementedException();
    }

    public Employee? AuthEmployee(string login, string password)
    {
        throw new NotImplementedException();
    }

    public House? GetHouseById(int id)
    {
        throw new NotImplementedException();
    }

    public Employee? GetEmployeeById(int id)
    {
        throw new NotImplementedException();
    }
}