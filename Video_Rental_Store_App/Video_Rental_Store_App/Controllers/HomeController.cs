using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Video_Rental_Store_App.Models;
using Services.Interfaces;
using Services.Implementation;

namespace Video_Rental_Store_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _userService = new UserService();
        }

        public IActionResult Index()
        {
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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            {
                var authenticatedUser = _userService.AuthenticateUser(user.CardNumber);
                if (authenticatedUser != null)
                {
                    HttpContext.Session.SetString("UserId", authenticatedUser.Id.ToString());
                    return RedirectToAction("Index", "Movies");
                }

                ModelState.AddModelError("", "Invalid card number");
                return View(user);
            }
        }
    }
}
