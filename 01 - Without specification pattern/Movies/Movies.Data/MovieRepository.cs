using System.Collections.Generic;
using System.Linq;

namespace Movies.Data
{
    public class MovieRepository
    {

        public Movie Get(int id)
        {
            using (var context = new MoviesContext())
            {
                return context.Movies.FirstOrDefault(x => x.Id == id);
            }
        }
        public IReadOnlyCollection<Movie> GetAll()
        {
            using (var context = new MoviesContext())
            {
                return context.Movies.ToList();
            }
        }
        public IReadOnlyList<Movie> Get(
            //bool forChildsOnly,
            double minimumRating,
            bool onlyFullHd
            //,bool enable
            )
        {
            //TODO: 01 - Se deben retornar las peliculas para chicos
            using (var context = new MoviesContext())
            {
                return context.Movies
                    .Where(x =>
                        //(!forChildsOnly || x.Type <= MovieType.Teen)
                        //&&
                        x.Rating >= minimumRating
                        &&
                        (!onlyFullHd && x.IsFullHd)
                        //&&
                        //!enable || (x.Quantity > 0 && x.ReleaseDate > DateTime.Now.AddYears(-1))
                        )
                    .ToList();
                //TODO: 02 - Se deben retornar las peliculas Habilitadas

            }
        }
    }
}