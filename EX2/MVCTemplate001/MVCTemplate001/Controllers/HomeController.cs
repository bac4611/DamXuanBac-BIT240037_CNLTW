using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCTemplate001.Models;

namespace MVCTemplate001.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        ViewData["Name"] = "Nguyen Van A";
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Email"] = "email@example.com";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
