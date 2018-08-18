using Movies.Data;
using Xunit;

namespace Movies.Test
{
    public class MovieServiceShould
    {
        private MovieService _movieService;

        public MovieServiceShould()
        {
            _movieService = new MovieService();
        }
        [Fact]
        public void PassingTest()
        {
        }
    }
}
