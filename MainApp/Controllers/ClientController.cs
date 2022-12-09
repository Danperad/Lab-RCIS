using LabsDB.Entity;
using MainApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MainApp.Controllers;

[ApiController]
[Route("/client")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("get")]
    public IEnumerable<House> GetHouses()
    {
        return _clientService.GetAllHouses();
    }
}