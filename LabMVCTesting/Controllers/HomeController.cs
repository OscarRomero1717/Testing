using ConversorJson;
using LabMVCTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LabMVCTesting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ServiceConverter _serviceConverter;

        public HomeController(ILogger<HomeController> logger, IConversorJson _conversorJson)
        {
            _serviceConverter = new ServiceConverter(_conversorJson);
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Index(string json)
        {
           string ok=  _serviceConverter.Convert(json);
            TempData["ok"] = ok;
            return View("Index");

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