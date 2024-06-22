using Microsoft.AspNetCore.Mvc;
using ViewModels;
using DataAccess;
using DomainModels;
using System.Diagnostics;
using Video_Rental_Store_App.Models;
using Services.Interfaces;
using Services.Implementation;
using DomainModels.Enums;

namespace Video_Rental_Store_App.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
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
        public IActionResult Login(LoginViewModel model)
        {
            {
                var authenticatedUser = _userService.AuthenticateUser(model.CardNumber);
                if (authenticatedUser != null)
                {
                    HttpContext.Session.SetString("UserId", authenticatedUser.Id.ToString());
                    return RedirectToAction("Index", "Movies");
                }

                ModelState.AddModelError("", "Invalid card number");
                return View(model);
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            _userService.RegisterUser(userViewModel);
            return RedirectToAction("Login");
        }
    }
}
