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

            //TODO: 03 - Utilizo las expresiones
            var isEnable = Movie.IsForChild.Compile();
            if (isEnable(movie))
                return movie;

            return null;
        }

        public Movie BuyEnableMovie(int id)
        {
            var movie = _movieRepository.Get(id);

            if (movie == null) return null;


            //TODO: 06 - Utilizo el generic Specification
            //var specification = new GenericSpecification<Movie>(x => x.Quantity > 0 && x.ReleaseDate > DateTime.Now.AddYears(-1));
            //if (specification.IsSatisfiedBy(movie))

            //TODO: 04 - Utilizo las expresiones
            var isEnable = Movie.IsEnable.Compile();
            if (isEnable(movie))
                return movie;

            return null;
        }
    }
}