using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FindBookBackend.Models;

namespace FindBookBackend.Controllers;

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

    //opened my github profile page
    public ActionResult DirectGithub()
    {
        // İlgili sayfaya yönlendirme işlemi
        return Redirect("https://github.com/ViselnikAscet");
    }
    
      public ActionResult DirectBook()
    {
        // İlgili sayfaya yönlendirme işlemi
        return View("Books");
    }


    public ActionResult DirectLib()
    {
        // İlgili sayfaya yönlendirme işlemi
        return RedirectToAction("Index", "Library");
    }

    public ActionResult DirectLeaderBoard()
    {
        // İlgili sayfaya yönlendirme işlemi
        return RedirectToAction("Index", "Scoreboard");
    }


    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
