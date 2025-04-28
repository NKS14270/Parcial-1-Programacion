using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Parcial_1__Programacion.Models;
using Parcial_1__Programacion.Data;

namespace Parcial_1__Programacion.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public DataDB data = new DataDB();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        data.VerificarTablaObraSocial();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
