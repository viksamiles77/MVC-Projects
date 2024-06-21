using DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Video_Rental_Store_App.Controllers
{
    public class RentalsController : Controller
    {
        private readonly List<Rental> _rentals = new List<Rental>();
        private readonly List<Movie> _movies = new List<Movie>();

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var userRentals = _rentals.Where(r => r.UserId == int.Parse(userId)).ToList();
            var rentedMovies = userRentals.Select(r => new {
                Movie = _movies.FirstOrDefault(m => m.Id == r.MovieId),
                Rental = r
            }).ToList();

            return View(rentedMovies);
        }

        //maybe add in services
        [HttpPost]
        public IActionResult Return(int id)
        {
            var rental = _rentals.FirstOrDefault(r => r.Id == id);
            if (rental == null)
            {
                return NotFound();
            }

            rental.ReturnedOn = DateTime.Now;
            var movie = _movies.FirstOrDefault(m => m.Id == rental.MovieId);
            if (movie != null)
            {
                movie.Quantity++;
            }

            return RedirectToAction("Index");
        }
    }
}
