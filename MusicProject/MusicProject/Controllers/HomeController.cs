using Microsoft.AspNetCore.Mvc;
using MusicProject.Models;
using System.Diagnostics;

namespace MusicProject.Controllers
{
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

        //Adding the IActionResult methods for each page
        public IActionResult Artists()
        {
            
            return View();
        }

        public IActionResult Songs()
        {
            
            return View();
        }

        public IActionResult Users()
        {
            
            return View();
        }

        public IActionResult Playlists()
        {
            
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
}