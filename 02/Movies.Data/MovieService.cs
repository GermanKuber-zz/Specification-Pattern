using System;

namespace Movies.Data
{
    public class MovieService
    {
        private readonly MovieRepository _movieRepository;

        public MovieService()
        {
            _movieRepository = new MovieRepository();
        }

        public Movie BuyChildrenMovie(int id)
        {
            var movie = _movieRepository.Get(id);

            if (movie == null) return null;

            if (movie.Type <= MovieType.Teen)
                return movie;

            return null;
        }

        public Movie BuyEnableMovie(int id)
        {
            var movie = _movieRepository.Get(id);

            if (movie == null) return null;

            if (movie.Quantity > 0 && movie.ReleaseDate > DateTime.Now.AddYears(-1))
                return movie;

            return null;
        }
    }
}