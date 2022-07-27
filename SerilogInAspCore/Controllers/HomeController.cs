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

            var position2 = new { Latitude = 23, Longitude = 124 };
            var elapsedMs = 34;
            _logger.LogError("Processed serialize {@Position} in {Elapsed:000} ms.", position, elapsedMs);
            _logger.LogError("Processed tostring {Position} in {Elapsed:000} ms.", position, elapsedMs);

            _logger.LogError("Processed serialize {@Position} in {Elapsed:000} ms.", position2, elapsedMs);

            _logger.LogInformation("info log");
            _logger.LogCritical("critical log");
            _logger.LogTrace("trace log");
            _logger.LogDebug("debug log");
            _logger.LogWarning("waning log");

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