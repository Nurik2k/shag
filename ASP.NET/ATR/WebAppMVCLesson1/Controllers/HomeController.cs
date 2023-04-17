using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebAppMVCLesson1.Models;

namespace WebAppMVCLesson1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EFContext _db;

        public HomeController(ILogger<HomeController> logger, EFContext db)
        {
            _logger = logger;
            _db = db;
        }



        public IActionResult Index()
        {
            string useremail = "gersen.e.a@gmail.com";
            DateTime dateTime = DateTime.Now;

            try
            {
                Room rm = new Room();
                rm.RoomNumber = 501;

                _logger.LogInformation(
                    "A user with email: {useremail} logged in {dateTime} {rm}",
                    useremail, dateTime, rm);


                _logger.LogInformation("LogInformation");
                _logger.LogError("LogError");

                throw new Exception("test Error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Location()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult WrongEdg()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(f=>f.UserName == username && f.Password == password);
            if (user == null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}