using LabsDB.Entity;
using MainApp;
using MainApp.Controllers;
using MainApp.Repositories;
using Moq;

namespace Tests.MainApp;

public class MainAppMockTest
{
    private readonly IEnumerable<House> _testHouses;

    public MainAppMockTest()
    {
        var testHouses = new List<House>();
        var e = new Employee {Id = 1, Login = "Test", Password = "Test"};
        for (var i = 1; i < 3; i++)
        {
            var home = new House {Id = i};
            var ind0 = new Indication("Свет", 100 * i, home, e);
            var ind1 = new Indication("Вода", 200 * i, home, e);
            home.Indications.Add(ind0);
            home.Indications.Add(ind1);
            testHouses.Add(home);
        }

        _testHouses = testHouses;
    }

    [Test]
    public void GetAllHousesSuccess()
    {
        var mock = new Mock<IClientRepository>();
        mock.Setup(r => r.GetAllHouses()).Returns(_testHouses);
        var clientController = new ClientController(mock.Object);
        var result = clientController.GetHouses();
        Assert.That(result.Count(), Is.EqualTo(_testHouses.Count()));
    }

    [Test]
    public void AddNewIndicationSuccess()
    {
        var mock = new Mock<IAgentRepository>();
        mock.Setup(r => r.AddNewIndication(It.IsNotNull<Indication>())).Returns(true);
        var agentController = new AgentController(mock.Object);
        var res = agentController.AddNewIndication(new NewRequest());
        Assert.That(res.Res, Is.True);
    }

    [Test]
    public void AddNewIndicationWithNull()
    {
        var mock = new Mock<IAgentRepository>();
        mock.Setup(r => r.AddNewIndication(It.IsNotNull<Indication>())).Returns(true);
        var agentController = new AgentController(mock.Object);
#pragma warning disable CS8625
        var res = agentController.AddNewIndication(null);
#pragma warning restore CS8625
        Assert.That(res.Res, Is.False);
    }

    [Test]
    public void AddNewIndicationWithErrorHouse()
    {
        var mock = new Mock<IAgentRepository>();
        mock.Setup(r => r.AddNewIndication(It.Is<Indication>(i => i.HouseId > 0))).Returns(true);
        var agentController = new AgentController(mock.Object);
        var res = agentController.AddNewIndication(new NewRequest{House = -1});
        Assert.That(res.Res, Is.False);
    }

    [Test]
    public void AddNewIndicationWithErrorEmployee()
    {
        var mock = new Mock<IAgentRepository>();
        mock.Setup(r => r.AddNewIndication(It.Is<Indication>(i => i.EmployeeId > 0))).Returns(true);
        var agentController = new AgentController(mock.Object);
        var res = agentController.AddNewIndication(new NewRequest {NowEmployee = -1});
        Assert.That(res.Res, Is.False);
    }

    [Test]
    public void AddNewIndicationWithErrorValue()
    {
        var mock = new Mock<IAgentRepository>();
        mock.Setup(r => r.AddNewIndication(It.Is<Indication>(i => i.Value > 0))).Returns(true);
        var agentController = new AgentController(mock.Object);
        var res = agentController.AddNewIndication(new NewRequest {Value = -1});
        Assert.That(res.Res, Is.False);
    }

    [TestCase("   ", ExpectedResult = false)]
    [TestCase(null, ExpectedResult = false)]
    public bool AddNewIndicationWithEmptyString(string res)
    {
        var mock = new Mock<IAgentRepository>();
        mock.Setup(r => r.AddNewIndication(It.Is<Indication>(i => !string.IsNullOrWhiteSpace(i.Title)))).Returns(true);
        var agentController = new AgentController(mock.Object);
        return agentController.AddNewIndication(new NewRequest {Title = res}).Res;
    }

    [Test]
    public void AuthSuccess()
    {
        var mock = new Mock<IAgentRepository>();
        mock.Setup(r => r.AuthEmployee(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(new Employee {Id = 1, Login = "Test", Password = "Test"});
        var agentController = new AgentController(mock.Object);
        var res = agentController.Auth(new AuthRequest{Login = "Test", Password = "Test"});
        Assert.That(res, Is.Not.Null);
    }

    [TestCase("   ", "test")]
    [TestCase("test", "    ")]
    [TestCase("   ", "    ")]
    [TestCase(null, "test")]
    [TestCase("test", null)]
    [TestCase(null, null)]
    public void AuthWithErrorData(string login, string password)
    {
        var mock = new Mock<IAgentRepository>();
        mock.Setup(r => r.AuthEmployee(It.Is<string>(s => !string.IsNullOrWhiteSpace(s)),
                It.Is<string>(s => !string.IsNullOrWhiteSpace(s))))
            .Returns(new Employee {Id = 1, Login = "Test", Password = "Test"});
        var agentController = new AgentController(mock.Object);
        var res = agentController.Auth(new AuthRequest{Login = login, Password = password});
        Assert.That(res, Is.Null);
    }
}