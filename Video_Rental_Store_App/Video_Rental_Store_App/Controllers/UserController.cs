using Microsoft.AspNetCore.Mvc;
using ViewModels;
using System.Diagnostics;
using Video_Rental_Store_App.Models;
using Services.Interfaces;
using Storage;
using Services.Implementation;

namespace Video_Rental_Store_App.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public UserController(ILogger<UserController> logger, IUserService userService, IMovieService movieService)
        {
            _logger = logger;
            _userService = userService;
            _movieService = movieService;
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
            var authenticatedUser = _userService.AuthenticateUser(model.CardNumber);
            if (authenticatedUser != null)
            {
                CurrentSession.Set(authenticatedUser);
                HttpContext.Session.SetString("UserId", authenticatedUser.Id.ToString());
                if (CurrentSession.CurrentUser.IsAdmin == true)
                {
                    return RedirectToAction("AdminIndex", "Movies");
                }
                else
                {
                    return RedirectToAction("Index", "Movies");
                }
            }

            ModelState.AddModelError("", "Invalid card number");
            return View(model);
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

        public IActionResult Logout()
        {
            _userService.Logout();
            return RedirectToAction("Login");
        }

        public IActionResult RentMovie(int id)
        {
            _movieService.Rent(id, CurrentSession.CurrentUser.Id);

            return RedirectToAction("Index", "Movies");
        }

        public IActionResult ReturnMovie(int id)
        {
            _movieService.Return(id);

            return RedirectToAction("UserMovies");
        }
        public IActionResult UserMovies()
        {
            var user = CurrentSession.CurrentUser;
            var rentals = _movieService.GetRentals().Where(x => x.UserId == user.Id).ToList();
            var userRentalModel = new UserRentalViewModel()
            {
                Rentals = rentals,
                User = new UserViewModel()
                {
                    Id = user.Id,
                }
            };
            return View(userRentalModel);
        }
        public IActionResult BackBtn()
        {
            return RedirectToAction("Index", "Movies");
        }
    }
}
