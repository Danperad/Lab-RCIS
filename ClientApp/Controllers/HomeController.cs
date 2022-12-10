﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClientApp.Models;
using ClientApp.Repositories;

namespace ClientApp.Controllers;

public class HomeController : Controller
{
    private readonly IClientRepository _clientRepository;

    public HomeController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public IActionResult Index()
    {
        throw new NotImplementedException();
        return View(new HouseViewModel(){Houses = _clientRepository.GetAllHouses()});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}