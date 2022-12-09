using LabsDB.Entity;
using MainApp.Interfaces;

namespace Tests.Services;

public class TestAgentService : IAgentService
{
    private static readonly Employee _employee = new() {Id = 1, Login = "test", Password = "test"};
    private static readonly List<House> _houses = Enumerable.Range(1, 10).Select(r => new House{Id = r}).ToList();

    public bool AddNewIndication(Indication indication)
    {
        if (indication is null || indication.Value <= 0 || string.IsNullOrWhiteSpace(indication.Title)) return false;
        
        return _houses.Any(h => h.Id == indication.HouseId);
    }

    public Employee? AuthEmployee(string login, string password)
    {
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)) return null;
        if (login == _employee.Login && password == _employee.Password) return _employee;
        return null;
    }

    public House? GetHouseById(int id)
    {
        return _houses.FirstOrDefault(h => h.Id == id);
    }

    public Employee? GetEmployeeById(int id)
    {
        return id == _employee.Id ? _employee : null;
    }
}