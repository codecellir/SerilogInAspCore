using Microsoft.AspNetCore.Mvc;
using SerilogInAspCore.Models;
using System.Diagnostics;

namespace SerilogInAspCore.Controllers
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
            var position = new { Latitude = 25, Longitude = 134 };
            var elapsedMs = 34;
            _logger.LogError("Processed serialize {@Position} in {Elapsed:000} ms.", position, elapsedMs);
            _logger.LogError("Processed tostring {Position} in {Elapsed:000} ms.", position, elapsedMs);

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