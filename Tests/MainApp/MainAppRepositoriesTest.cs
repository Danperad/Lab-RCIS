using LabsDB.Entity;
using MainApp;
using MainApp.Services;
using Microsoft.EntityFrameworkCore;

namespace Tests.MainApp;

public class MainAppRepositoriesTest
{
    private ApplicationContext _context;

    public MainAppRepositoriesTest()
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase($"ContextDb_{DateTime.Now.ToFileTimeUtc()}").Options;
        _context = new ApplicationContext(options);
        FillDb();
    }

    private void FillDb()
    {
        var testHouses = new List<House>();
        var employee = new Employee {Id = 1, Login = "test", Password = "test"};
        _context.Employees.Add(employee);
        for (var i = 1; i < 3; i++)
        {
            var home = new House {Id = i};
            var ind0 = new Indication("Свет", 100 * i, home, employee);
            var ind1 = new Indication("Вода", 200 * i, home, employee);
            home.Indications.Add(ind0);
            home.Indications.Add(ind1);
            testHouses.Add(home);
        }

        _context.AddRange(testHouses);
        _context.SaveChanges();
    }

    ~MainAppRepositoriesTest()
    {
        _context.Dispose();
    }

    [Test]
    public void GetAllHouses()
    {
        var service = new ClientService(_context);
        Assert.That(service.GetAllHouses(), Is.InstanceOf<IEnumerable<House>>());
    }

    [Test]
    public void AddNewIndicationSuccess()
    {
        var service = new AgentService(_context);
        var house = _context.Houses.FirstOrDefault();
        var employee = _context.Employees.FirstOrDefault();
        Assert.That(service.AddNewIndication(new Indication("Абра", 2.0D, house, employee)), Is.True);
    }

    [Test]
    public void AddNewIndicationWithNullHouse()
    {
        var service = new AgentService(_context);
        House house = null;
        var employee = _context.Employees.FirstOrDefault();
        Assert.Catch<NullReferenceException>(() =>
            service.AddNewIndication(new Indication("Абра", 2.0D, house, employee)));
    }

    [Test]
    public void AddNewIndicationWithNullEmployee()
    {
        var service = new AgentService(_context);
        var house = _context.Houses.FirstOrDefault();
        Employee employee = null;
        Assert.Catch<NullReferenceException>(() =>
            service.AddNewIndication(new Indication("Абра", 2.0D, house, employee)));
    }

    [TestCase("   ")]
    [TestCase(null)]
    public void AddNewIndicationWithErrorTitle(string title)
    {
        var service = new AgentService(_context);
        var house = _context.Houses.FirstOrDefault();
        var employee = _context.Employees.FirstOrDefault();
        Assert.That(service.AddNewIndication(new Indication(title, 2.0D, house, employee)), Is.False);
    }

    [Test]
    public void AddNewIndicationWithErrorValue()
    {
        var service = new AgentService(_context);
        var house = _context.Houses.FirstOrDefault();
        var employee = _context.Employees.FirstOrDefault();
        Assert.That(service.AddNewIndication(new Indication("Test", -2.0D, house, employee)), Is.False);
    }

    [TestCase("test", "test", ExpectedResult = true)]
    [TestCase("test1", "test", ExpectedResult = false)]
    [TestCase("   ", "test", ExpectedResult = false)]
    [TestCase("test", "    ", ExpectedResult = false)]
    [TestCase("   ", "    ", ExpectedResult = false)]
    [TestCase(null, "test", ExpectedResult = false)]
    [TestCase("test", null, ExpectedResult = false)]
    [TestCase(null, null, ExpectedResult = false)]
    public bool AuthWithErrorData(string login, string password)
    {
        var service = new AgentService(_context);
        return service.AuthEmployee(login, password) is null;
    }
}