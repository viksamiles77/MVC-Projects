using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Storage;
using ViewModels;

namespace Video_Rental_Store_App.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public MoviesController(IMovieService movieService, IUserService userService)
        {
            _movieService = movieService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            ViewBag.Message = "No movies available";
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        public IActionResult Create()
        {
            if (CurrentSession.CurrentUser.IsAdmin == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create([FromForm] MovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            _movieService.AddMovie(movie);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            if (CurrentSession.CurrentUser.IsAdmin == true)
            {
                return View(movie);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit([FromForm] MovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _movieService.UpdateMovie(model);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (CurrentSession.CurrentUser.IsAdmin == true)
            {
                _movieService.DeleteMovie(id);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}

