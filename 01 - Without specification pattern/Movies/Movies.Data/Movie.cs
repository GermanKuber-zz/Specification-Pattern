using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Movies.Data
{
    public class Movie : Entity
    {
        public virtual string Name { get; }
        public virtual DateTime ReleaseDate { get; }
        public virtual MovieType Type { get; }
        public virtual double Rating { get; }
    }

    public enum MovieType
    {
        Kids,
        Teen,
        Adult,
        Xxx
    }


    public class MovieRepository
    {

        public IReadOnlyCollection<Movie> GetAll()
        {
            return new List<Movie>();
        }
    }
}
