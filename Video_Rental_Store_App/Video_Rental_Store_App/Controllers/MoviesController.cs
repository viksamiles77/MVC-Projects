using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels;

namespace Video_Rental_Store_App.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
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
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm]MovieViewModel movie)
        {
            if(!ModelState.IsValid)
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
            return View(movie);
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
            _movieService.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }
}

