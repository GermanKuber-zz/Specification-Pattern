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
        //TODO: 03 - Se deben comprar peliculas solo para chicos
        public Movie BuyChildrenMovie(int id)
        {
            var movie = _movieRepository.Get(id);

            if (movie == null) return null;

            if (movie.Type <= MovieType.Teen)
                return movie;

            return null;
        }
        //TODO: 04 - Se deben comprar peliculas solo habilitadas
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