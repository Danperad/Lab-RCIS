using Grpc.Core;
using LabsDB.Entity;
using MainApp.Repositories;

namespace MainApp.Controllers;

public class AgentController : Agent.AgentBase
{
    private readonly IAgentRepository _agentService;

    public AgentController(IAgentRepository agentService)
    {
        _agentService = agentService;
    }

    public Employee? Auth(string login, string password)
    {
        return _agentService.AuthEmployee(login, password);
    }
    
    public override Task<ResponseEmployee> Auth(AuthRequest request, ServerCallContext context)
    {
        var e = Auth(request.Login, request.Password);
        if (e is null) return Task.FromResult(new ResponseEmployee());
        return Task.FromResult(new ResponseEmployee
        {
            Id = e.Id, Login = e.Login, Password = e.Password
        });
    }

    public bool AddNewIndication(Indication indication)
    {
        return _agentService.AddNewIndication(indication);
    }
    
    public override Task<NewResponse> AddNewIndication(NewRequest request, ServerCallContext context)
    {
        var r = new Indication(request.Title, request.Value, _agentService.GetHouseById(request.House), _agentService.GetEmployeeById(request.NowEmployee));
        var res = AddNewIndication(r);
        return Task.FromResult(new NewResponse
        {
            Res = res
        });
    }
}