using System.Net;
using System.Text.Json;
using ClientApp.Services;
using LabsDB.Entity;
using Moq;

namespace ClientApp.Test;

public class ClientAppRepositoriesTest
{
    private readonly IEnumerable<House> _testHouses;

    public ClientAppRepositoriesTest()
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
    
    public class DelegatingHandlerStub : DelegatingHandler {
        private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _handlerFunc;
        public DelegatingHandlerStub()
        {
            
            _handlerFunc = (request, cancellationToken) =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.RequestMessage = request;
                var res = JsonSerializer.Serialize(new List<House>());
                response.Content = new StringContent(res);
                return Task.FromResult(response);
            };
        }

        public DelegatingHandlerStub(IEnumerable<House> testHouses)
        {
            _handlerFunc = (request, cancellationToken) =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.RequestMessage = request;
                var res = JsonSerializer.Serialize(testHouses);
                response.Content = new StringContent(res);
                return Task.FromResult(response);
            };
        }

        public DelegatingHandlerStub(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handlerFunc) {
            _handlerFunc = handlerFunc;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            return _handlerFunc(request, cancellationToken);
        }
    }
    
    [Test]
    public void GetHouseHttpSuccess()
    {
        var clientHandlerStub = new DelegatingHandlerStub(_testHouses);
        var client = new HttpClient(clientHandlerStub);
        var mock = new Mock<IHttpClientFactory>();
        mock.Setup(r => r.CreateClient(It.IsAny<string>())).Returns(client);
        var service = new ClientService(mock.Object);
        var res = service.GetAllHouses();
        Assert.That(res.Count(), Is.EqualTo(_testHouses.Count()));
    }
    
    [Test]
    public void GetHouseHttpError()
    {
        var client = new HttpClient();
        var mock = new Mock<IHttpClientFactory>();
        mock.Setup(r => r.CreateClient(It.IsAny<string>())).Returns(client);
        var service = new ClientService(mock.Object);
        var res = service.GetAllHouses();
        Assert.That(res.Count(), Is.EqualTo(0));
    }
}