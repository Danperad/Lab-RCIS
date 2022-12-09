using Grpc.Core;
using LabsDB.Entity;
using MainApp.Interfaces;

namespace MainApp.Controllers;

public class AgentController : Agent.AgentBase
{
    private readonly IAgentService _agentService;

    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }

    public override Task<ResponseEmployee> Auth(AuthRequest request, ServerCallContext context)
    {
        var e = _agentService.AuthEmployee(request.Login, request.Password);
        if (e is null) return Task.FromResult(new ResponseEmployee());
        return Task.FromResult(new ResponseEmployee
        {
            Id = e.Id, Login = e.Login, Password = e.Password
        });
    }

    public override Task<NewResponse> AddNewIndication(NewRequest request, ServerCallContext context)
    {
        var r = new Indication(request.Title, _agentService.GetHouseById(request.House), _agentService.GetEmployeeById(request.NowEmployee));
        return Task.FromResult(new NewResponse
        {
            Res = _agentService.AddNewIndication(r)
        });
    }
}