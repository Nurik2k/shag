using APIConsumer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace APIConsumer.Controllers
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
            List<Reservation> reservations = new List<Reservation>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5177/api/Reservation"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservations = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                }
                return View(reservations);
            }
        }

        public ViewResult GetReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetReservation(int Id)
        {
            Reservation reservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5177/api/Reservation/"+Id))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }
                }
                return View(reservation);
            }
        }

        public ViewResult AddReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(Reservation reservation)
        {
            Reservation recivedReservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");
                using (var responce = await httpClient.PostAsync("http://localhost:5285/api/Reservation", content))
                {
                    string apiResponce = await responce.Content.ReadAsStringAsync();
                    recivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponce);
                }
            }
            return View(recivedReservation);
        }
    }
}