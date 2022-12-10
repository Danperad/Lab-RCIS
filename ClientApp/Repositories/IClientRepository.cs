using LabsDB.Entity;

namespace ClientApp.Repositories;

public interface IClientRepository
{
    IEnumerable<House> GetAllHouses();
}