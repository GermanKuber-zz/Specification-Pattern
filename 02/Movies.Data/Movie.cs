using System;

namespace Movies.Data
{
    public class Movie : Entity
    {
        public string Name { get; set; }
        public bool IsFullHd { get; set; }
        public DateTime ReleaseDate { get; set; }
        public MovieType Type { get; set; }
        public double Rating { get; set; }
        public int Quantity { get; set; }

        public bool IsEnable()
        {
            return Quantity > 0 && ReleaseDate > DateTime.Now.AddYears(-1);
        }
        public bool IsForChild()
        {
            return Type <= MovieType.Teen;
        }
    }
}
