using DomainModels;
using ViewModels;

namespace Mappers
{
    public static class MovieMapper
    {
        public static MovieViewModel ToModel(this Movie movie)
        {
            var viewModel = new MovieViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                ReleaseDate = movie.ReleaseDate,
                Length = movie.Length,
                AgeRestriction = movie.AgeRestriction,
                Quantity = movie.Quantity,
            };
            return viewModel;
        }

        public static Movie ToEntity(this MovieViewModel viewModel)
        {
            var movie = new Movie()
            {
                Title = viewModel.Title,
                Genre = viewModel.Genre,
                Language = viewModel.Language,
                ReleaseDate = viewModel.ReleaseDate,
                Length = viewModel.Length,
                AgeRestriction = viewModel.AgeRestriction,
                Quantity = viewModel.Quantity
            };
            return movie;
        }

        public static MovieViewModel ToViewModel(this Movie movie)
        {
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
    }
}
