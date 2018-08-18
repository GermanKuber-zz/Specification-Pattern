using System;
using Microsoft.EntityFrameworkCore;

namespace Movies.Data
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 1, Name = "Deadpool 1", IsFullHd = false, Type = MovieType.Teen, Rating = 7.8, ReleaseDate = new DateTime(2017, 5, 2) });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 2, Name = "Deadpool 2", IsFullHd = true, Type = MovieType.Teen, Rating = 8, ReleaseDate = new DateTime(2018, 5, 2) });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 3, Name = "Pantera Negra", Rating = 6, ReleaseDate = new DateTime(2018, 1, 2) });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 4, Name = "Los Increibles 2", IsFullHd = true, Type = MovieType.Kids, Rating = 6.7, ReleaseDate = new DateTime(2018, 2, 2) });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 5, Name = "La Monja", IsFullHd = true, Type = MovieType.Terror, Rating = 7.6, ReleaseDate = new DateTime(2018, 8, 2) });

            base.OnModelCreating(modelBuilder);
        }
    }
}