using System;
using System.Linq.Expressions;

namespace Movies.Data
{
    public class Movie : Entity
    {
        //TODO: 01 - Creo las expresiones
        public static Expression<Func<Movie, bool>> IsEnable =>
           x => x.Quantity > 0 && x.ReleaseDate > DateTime.Now.AddYears(-1);

        public static Expression<Func<Movie, bool>> IsForChild =>
            x => x.Type <= MovieType.Teen;

        public string Name { get; set; }
        public bool IsFullHd { get; set; }
        public DateTime ReleaseDate { get; set; }
        public MovieType Type { get; set; }
        public double Rating { get; set; }
        public int Quantity { get; set; }

    }
}
