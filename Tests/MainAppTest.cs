using System.Net.Http.Json;
using LabsDB.Entity;
using MainApp;
using MainApp.Interfaces;
using MainApp.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Tests.Services;

namespace Tests;

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
                    new(typeof(IClientService), typeof(ClientService), ServiceLifetime.Transient);
                services.Remove(serviceDescriptor);
                services.AddTransient<IClientService>(_ => new TestClientService());
            });
        });
        using var client = server.CreateClient();
        var res = await client.GetFromJsonAsync<IEnumerable<House>>("/client/get");
        Assert.That(res!.Count(), Is.EqualTo(2));
    }
    
    [Test]
    public async Task AuthEmployeeSuccess()
    {
        await using var server = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                ServiceDescriptor serviceDescriptor =
                    new(typeof(IClientService), typeof(ClientService), ServiceLifetime.Transient);
                services.Remove(serviceDescriptor);
                services.AddTransient<IClientService>(_ => new TestClientService());
            });
        });
        using var client = server.CreateClient();
        var res = await client.GetFromJsonAsync<IEnumerable<House>>("/client/get");
        Assert.That(res!.Count(), Is.EqualTo(2));
    }
}