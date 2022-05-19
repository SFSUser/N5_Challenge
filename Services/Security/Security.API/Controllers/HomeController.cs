using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Security.API.Controllers;

[Controller]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]
    public IActionResult Home()
    {
        return View();
    }
}
