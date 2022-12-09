using System.Net.Http.Json;
using LabsDB.Entity;
using MainApp;
using MainApp.Repositories;
using MainApp.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Tests.Services;

namespace Tests.MainApp;

public class MainAppTest
{
    [Test]
    public async Task GetAllClientItemsSuccess()
    {
        await using var server = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                ServiceDescriptor serviceDescriptor =
                    new(typeof(IClientRepository), typeof(ClientService), ServiceLifetime.Transient);
                services.Remove(serviceDescriptor);
                services.AddTransient<IClientRepository>(_ => new TestClientService());
            });
        });
        using var client = server.CreateClient();
        var res = await client.GetFromJsonAsync<IEnumerable<House>>("/client/get");
        Assert.That(res!.Count(), Is.EqualTo(2));
    }
}