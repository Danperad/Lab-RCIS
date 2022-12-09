using MainApp.Controllers;
using MainApp.Repositories;
using MainApp.Services;

namespace MainApp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddGrpc();
        builder.Services.AddTransient<IAgentRepository, AgentService>();
        builder.Services.AddTransient<IClientRepository, ClientService>();
        var app = builder.Build();

        app.MapGrpcService<AgentController>();
        app.MapControllers();

        app.Run();
    }
}