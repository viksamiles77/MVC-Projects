using DomainModels;
using DomainModels.Enums;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels;

namespace Video_Rental_Store_App.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public IActionResult Index()
        {
            var movies = _movieService.GetAll();
            var movieViewModels = movies.Select(m => new MovieViewModel
            {
                Id = m.Id,
                Title = m.Title,
                Genre = m.Genre,
                IsAvailable = m.IsAvailable,
                ReleaseDate = m.ReleaseDate,
                Length = m.Length,
                AgeRestriction = m.AgeRestriction,
                Quantity = m.Quantity
            }).ToList();

            return View(movieViewModels);
        }

        public IActionResult Details(int id)
        {
            var movies = _movieService.GetAll();
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }


        //maybe add this in services
        [HttpPost]
        public IActionResult Rent(int id)
        {
            var movies = _movieService.GetAll();
            var movie = movies.FirstOrDefault(x => x.Id == id);
            if (movie == null || movie.Quantity <= 0)
            {
                return BadRequest("Movie is not available for rent");
            }

            var userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var rental = new Rental
            {
                MovieId = movie.Id,
                UserId = int.Parse(userId),
                RentedOn = DateTime.Now
            };

            movie.Quantity--;
            return RedirectToAction("Index");
        }
    }
}
