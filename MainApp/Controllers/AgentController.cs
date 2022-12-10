using Grpc.Core;
using LabsDB.Entity;
using MainApp.Repositories;

namespace MainApp.Controllers;

public class AgentController : Agent.AgentBase
{
    private readonly IAgentRepository _agentRepository;

    public AgentController(IAgentRepository agentRepository)
    {
        _agentRepository = agentRepository;
    }

    public ResponseEmployee Auth(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public override Task<ResponseEmployee> Auth(AuthRequest request, ServerCallContext context)
    {
        return Task.FromResult(Auth(request));
    }

    public NewResponse AddNewIndication(NewRequest indication)
    {
        throw new NotImplementedException();
    }

    public override Task<NewResponse> AddNewIndication(NewRequest request, ServerCallContext context)
    {
        return Task.FromResult(AddNewIndication(request));
    }
}