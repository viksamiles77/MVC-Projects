using DataAccess.Interface;
using DomainModels;
using Services.Interfaces;
using ViewModels;
using Mappers;

namespace Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Rental> _rentalRepository;

        public MovieService(IRepository<Movie> movieRepository, IRepository<Rental> rentalRepository)
        {
            _movieRepository = movieRepository;
            _rentalRepository = rentalRepository;
        }
        public List<MovieViewModel> GetAllMovies()
        {
            var movies = _movieRepository.GetAll();
            return movies.Select(x => x.ToModel()).ToList();
        }
        public MovieViewModel GetMovieById(int id)
        {
            var movie = _movieRepository.GetById(id);

            if (movie == null)
            {
                return null;
            }

            return movie.ToViewModel();
        }
        public void AddMovie(MovieViewModel movieViewModel)
        {
            var movie = movieViewModel.ToEntity();

            _movieRepository.Add(movie);
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
        public void Rent(int movieId, int userId)
        {
            var movie = _movieRepository.GetById(movieId);
            _rentalRepository.Add(new Rental(userId, movieId));
            --movie.Quantity;
            _movieRepository.Update(movie);
        }
        public void Return(int rentalId)
        {
            var rental = _rentalRepository.GetById(rentalId);
            rental.Return();
            var movie = _movieRepository.GetById(rental.MovieId);
            movie.Quantity++;
            _rentalRepository.Update(rental);
            _movieRepository.Update(movie);
        }
        public List<RentalViewModel> GetRentals() => _rentalRepository.GetAll().Select(x => x.ToModel()).ToList();






    }
}
