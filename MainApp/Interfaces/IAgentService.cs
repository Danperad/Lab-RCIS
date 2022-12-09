using LabsDB.Entity;

namespace MainApp.Interfaces;

public interface IAgentService
{
    bool AddNewIndication(Indication indication);
    Employee? AuthEmployee(string login, string password);
    House? GetHouseById(int id);
    Employee? GetEmployeeById(int id);
}