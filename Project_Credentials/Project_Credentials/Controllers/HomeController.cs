using Microsoft.AspNetCore.Mvc;
using Project_Credentials.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
namespace Project_Credentials.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public  IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="Admin,Supervisor")]
        public IActionResult Sales()
        {
            return View();
        }
        public IActionResult Shopping()
        {
            return View();
        }
        public IActionResult Clients()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Profile()
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
