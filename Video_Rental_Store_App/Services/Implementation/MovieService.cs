using DataAccess.Interface;
using DomainModels;
using Services.Interfaces;
using ViewModels;

namespace Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;

        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<MovieViewModel> GetAllMovies()
        {
            return _movieRepository.GetAll().Select(m => new MovieViewModel
            {
                Id = m.Id,
                Title = m.Title,
                Genre = m.Genre,
                Language = m.Language,
                IsAvailable = m.IsAvailable,
                ReleaseDate = m.ReleaseDate,
                Length = m.Length,
                AgeRestriction = m.AgeRestriction,
                Quantity = m.Quantity
            }).ToList();
        }

        public MovieViewModel GetMovieById(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return null;
            }
            return new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                IsAvailable = movie.IsAvailable,
                ReleaseDate = movie.ReleaseDate,
                Length = movie.Length,
                AgeRestriction = movie.AgeRestriction,
                Quantity = movie.Quantity
            };
        }

        public void AddMovie(MovieViewModel movie)
        {
            var newMovie = new Movie
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                IsAvailable = movie.IsAvailable,
                ReleaseDate = movie.ReleaseDate,
                Length = movie.Length,
                AgeRestriction = movie.AgeRestriction,
                Quantity = movie.Quantity
            };
            _movieRepository.Add(newMovie);
        }

        public void UpdateMovie(MovieViewModel movie)
        {
            var existingMovie = _movieRepository.GetById(movie.Id);
            if (existingMovie == null)
            {
                throw new KeyNotFoundException($"Movie with ID {movie.Id} not found.");
            }

            existingMovie.Title = movie.Title;
            existingMovie.Genre = movie.Genre;
            existingMovie.Language = movie.Language;
            existingMovie.IsAvailable = movie.IsAvailable;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.Length = movie.Length;
            existingMovie.AgeRestriction = movie.AgeRestriction;
            existingMovie.Quantity = movie.Quantity;

            _movieRepository.Update(existingMovie);
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteById(id);
        }
    }
}
