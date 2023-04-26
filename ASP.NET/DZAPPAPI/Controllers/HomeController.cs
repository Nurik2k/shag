using DZAPPAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DZAPPAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                List<Product> products = new List<Product>();
                using (var response = await httpClient.GetAsync(""))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
                return View();
            }
        }
        public ViewResult GetProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetProduct(int Id)
        {
            Product product = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5177/api/Product/" + Id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        product = JsonConvert.DeserializeObject<Product>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
                return View(product);
            }
        }

        public ViewResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            Product recivedProducts = new Product();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
                using (var responce = await httpClient.PostAsync("http://localhost:5285/api/Procduct", content))
                {
                    string apiResponce = await responce.Content.ReadAsStringAsync();
                    recivedProducts = JsonConvert.DeserializeObject<Product>(apiResponce);
                }
            }
            return View(recivedProducts);
        }
    }
}