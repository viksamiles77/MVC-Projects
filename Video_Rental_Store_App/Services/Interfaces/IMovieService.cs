using ViewModels;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieViewModel> GetAllMovies();
        MovieViewModel GetMovieById(int id);
        void AddMovie(MovieViewModel movie);
        void UpdateMovie(MovieViewModel movie);
        void DeleteMovie(int id);
        public void Rent(int movieId, int userId);
        public void Return(int rentalId);
        public List<RentalViewModel> GetRentals();
    }
}
