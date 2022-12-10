using AgentApp.Repository;
using LabsDb.Agent;

namespace AgentApp;

public class Worker : BackgroundService
{
    private readonly IAgentRepository _agentRepository;

    public Worker(IAgentRepository agentRepository)
    {
        _agentRepository = agentRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            throw new NotImplementedException();
            await Task.Delay(3600000, stoppingToken);
        }
    }

    public async Task<ResponseEmployee> Auth(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<NewResponse> AddNewIndication(NewRequest request)
    {
        throw new NotImplementedException();
    }
}