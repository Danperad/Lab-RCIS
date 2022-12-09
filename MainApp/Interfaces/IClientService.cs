using LabsDB.Entity;

namespace MainApp.Interfaces;

public interface IClientService
{
    IEnumerable<House> GetAllHouses();
}