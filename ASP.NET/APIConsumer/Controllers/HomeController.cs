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
                using (var response = await httpClient.GetAsync("http://localhost:5177/api/Reservation/" + Id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
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
                httpClient.DefaultRequestHeaders.Add("Key", "VictoriaSecret");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");
                using (var responce = await httpClient.PostAsync("http://localhost:5177/api/Reservation", content))
                {
                    ViewBag.StatusCode = responce.StatusCode + "|" + responce.IsSuccessStatusCode;
                    string apiResponce = await responce.Content.ReadAsStringAsync();
                    recivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponce);
                }
            }
            return View(recivedReservation);
        }

        public async Task<IActionResult> UpdateReservation(int Id)
        {
            Reservation reservation = new Reservation();

            using (var httpClient = new HttpClient())
            {
                using (var responce = await httpClient.GetAsync("http://localhost:5177/api/Reservation/" + Id))
                {
                    string apiResponce = await responce.Content.ReadAsStringAsync();
                    reservation = JsonConvert.DeserializeObject<Reservation>(apiResponce);
                }
            }
            return View(reservation);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateReservation(Reservation reservation)
        {
            Reservation recievedReservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(reservation.Id.ToString()), "Id");
                content.Add(new StringContent(reservation.Id.ToString()), "Name");
                content.Add(new StringContent(reservation.Id.ToString()), "StartLocation");
                content.Add(new StringContent(reservation.Id.ToString()), "EndLocation");
                using (var responce = await httpClient.PutAsync("http://localhost:5177/api/Reservation", content))
                {
                    string apiResponse = await responce.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    ViewBag.StatusCode = responce.StatusCode + "|" + responce.IsSuccessStatusCode;
                    recievedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                }
            }
            return View(recievedReservation);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReservation(int ReservationId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var responce = await httpClient.DeleteAsync("http://localhost:5177/api/Reservation/" + ReservationId))
                {
                    string apiResponce = await responce.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
        public ViewResult AddFile() => View();

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            string apiResponce = "";
            using (var httpClient = new HttpClient())
            {
                var form = new MultipartFormDataContent();

                using (var fileStream = file.OpenReadStream())
                {
                    form.Add(new StreamContent(fileStream), "file", file.FileName);
                    using (var responce = await httpClient.PostAsync("http://localhost:5177/api/Reservation/UploadFile", form))
                    {
                        apiResponce = await responce.Content.ReadAsStringAsync();
                    }
                }
            }
            return View((object)apiResponce);

        }
    }
}