using System;
using Microsoft.EntityFrameworkCore;

namespace Events.Data
{
    public class EventsContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EventsDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(new Event { Id = 1, Title = "Meetup.Js Event", Validated = false, Premium = false, EventDate = DateTime.Now.AddDays(7), Guests = 6 });
            modelBuilder.Entity<Event>().HasData(new Event { Id = 2, Title = "Specification Pattern en C#", Validated = false, Premium = false, EventDate = DateTime.Now.AddDays(1), Guests = 30 });
            modelBuilder.Entity<Event>().HasData(new Event { Id = 3, Title = "Azure and Docker", Validated = false, Premium = true, EventDate = DateTime.Now.AddDays(1), Guests = 25 });

            base.OnModelCreating(modelBuilder);
        }
    }
}