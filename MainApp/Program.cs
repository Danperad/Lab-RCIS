using MainApp.Controllers;
using MainApp.Repositories;
using MainApp.Services;
using Microsoft.EntityFrameworkCore;

namespace MainApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddGrpc();
        builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=test.db"));
        builder.Services.AddTransient<IAgentRepository, AgentService>();
        builder.Services.AddTransient<IClientRepository, ClientService>();
        var app = builder.Build();

        app.MapGrpcService<AgentController>();
        app.MapControllers();

        app.Run();
    }
}