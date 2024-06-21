using DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Video_Rental_Store_App.Controllers
{
    public class MoviesController : Controller
    {
        private readonly List<Movie> _movies = new List<Movie>
    {
        new Movie { Id = 1, Title = "James Bond", Genre = "Action", Quantity = 5, IsAvailable = true, ReleaseDate = DateTime.Now.AddMonths(-1), Length = TimeSpan.FromMinutes(120), AgeRestriction = 18 },
    };

        public IActionResult Index()
        {
            return View(_movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
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
            var movie = _movies.FirstOrDefault(x => x.Id == id);
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
