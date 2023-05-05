using DZ_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DZ_2.Controllers
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
            // Получение данных о компании из модели
            Company company = new Company();
            company.Name = "MyCompany";
            company.Description = "We make great products!";

            // Передача данных в представление
            return View(company);
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