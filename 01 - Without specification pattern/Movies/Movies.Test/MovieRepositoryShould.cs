using Movies.Data;
using Xunit;

namespace Movies.Test
{
    public class MovieRepositoryShould
    {
        private readonly MovieRepository _movieRepository;

        public MovieRepositoryShould()
        {
            _movieRepository = new MovieRepository();
        }
        [Fact]
        public void PassingTest()
        {
            var movies = _movieRepository.Get(9, false);
        }
    }
}
