using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using WebAPI_front.Models;

namespace WebAPI_front.Controllers
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
            var jwt = Request.Cookies["jwtCookie"];

            List<Reservation> reservations = new List<Reservation>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);

                using (var responce = await httpClient.GetAsync("http://localhost:5285/api/Reservation"))
                {
                    string apiResponce = await responce.Content.ReadAsStringAsync();
                    reservations = JsonConvert.DeserializeObject<List<Reservation>>(apiResponce);

                    ViewBag.StatusCode = responce.StatusCode;
                    _logger.LogInformation($"Reservation: {reservations}");
                }
            }

            _logger.LogInformation("LogInformation");
            _logger.LogError("Error");
            return View(reservations);

        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if ((username != "admin") || (password != "admin"))
            {
                return View((object)"Login Failed");
            }

            var accessToken = GenerateJSONWebToken();
            SetJWTCookie(accessToken);
            return View();

        }

        private void SetJWTCookie(string accessToken)
        {
            var CookieOption = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddMinutes(5)
            };
            Response.Cookies.Append("jwtCookie", accessToken, CookieOption);
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5285/",
                audience: "http://localhost:5285/",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public ViewResult GetReservation() { return View(); }

        [HttpPost]
        public async Task<IActionResult> GetReservation(int id)
        {
            Reservation reservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                using (var responce = await httpClient.GetAsync("http://localhost:5285/api/Reservation/" + id))
                {
                    if (responce.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponce = await responce.Content.ReadAsStringAsync();
                        reservation = JsonConvert.DeserializeObject<Reservation>(apiResponce);
                    }
                    else
                    {
                        ViewBag.StatusCode = responce.StatusCode;
                    }
                }
            }
            return View(reservation);
        }

        public ViewResult AddReservation() { return View(); }

        [HttpPost]
        public async Task<IActionResult> AddReservation(Reservation reservation)
        {
            Reservation recivedReservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Key", "VictoriasSecret");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");
                using (var responce = await httpClient.PostAsync("http://localhost:5285/api/Reservation", content))
                {
                    string apiResponce = await responce.Content.ReadAsStringAsync();

                    ViewBag.StatusCode = responce.StatusCode + " | " + responce.IsSuccessStatusCode;

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
                using (var responce = await httpClient.GetAsync("http://localhost:5285/api/Reservation/" + Id))
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
            Reservation recivedReservation = new Reservation();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(reservation.Id.ToString()), "Id");
                content.Add(new StringContent(reservation.Name.ToString()), "Name");
                content.Add(new StringContent(reservation.StartLocation.ToString()), "StartLocation");
                content.Add(new StringContent(reservation.EndLocation.ToString()), "EndLocation");

                using (var responce = await httpClient.PutAsync("http://localhost:5285/api/Reservation/", content))
                {
                    string apiResponce = await responce.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    ViewBag.StatusCode = responce.StatusCode + " | " + responce.IsSuccessStatusCode;
                    recivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponce);
                }
            }
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReservation(int ReservationId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var responce = await httpClient.DeleteAsync("http://localhost:5285/api/Reservation/" + ReservationId))
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
                    using (var responce = await httpClient.PostAsync("http://localhost:5285/api/Reservation/UploadFile", form))
                    {
                        apiResponce = await responce.Content.ReadAsStringAsync();
                    }
                }
            }
            return View((object)apiResponce);
        }
    }
}