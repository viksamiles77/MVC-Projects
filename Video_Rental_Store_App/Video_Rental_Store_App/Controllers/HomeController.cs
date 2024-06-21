using DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Video_Rental_Store_App.Models;
using Services.Interfaces;
using Services.Implementation;
using ViewModels;
using DomainModels.Enums;

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
        public IActionResult Register(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FullName = $"{userViewModel.FirstName} {userViewModel.LastName}",
                    Age = userViewModel.Age.Value,
                    CardNumber = userViewModel.CardNumber,
                    Email = userViewModel.Email,
                    Password = userViewModel.Password,
                    SubscriptionType = (SubscriptionTypeEnum)userViewModel.SubscriptionType,
                    CreatedOn = DateTime.Now,
                    IsSubscriptionExpired = false
                };
                _userService.RegisterUser(user);
                return RedirectToAction("Login");
            }

            return View(userViewModel);
        }
    }
}
