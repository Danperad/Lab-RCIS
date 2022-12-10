using AgentApp.Repository;
using LabsDb.Agent;

namespace AgentApp.Services;

public class AgentService: IAgentRepository
{
    public async Task<ResponseEmployee> Auth(AuthRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<NewResponse> AddNewIndication(NewRequest request)
    {
        throw new NotImplementedException();
    }
}