using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_duke95.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            // Leave blank
        }

        public DbSet<AddMovieResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<AddMovieResponse>().HasData(
                new AddMovieResponse
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = "",
                    Notes = ""
                },
                 new AddMovieResponse
                 {
                     MovieId = 2,
                     Category = "Action/Adventure",
                     Title = "Lord of the Rings: The Two Towers",
                     Year = 2002,
                     Director = "Peter Jackson",
                     Rating = "PG-13",
                     Edited = false,
                     Lent = "",
                     Notes = ""
                 },
                  new AddMovieResponse
                  {
                      MovieId = 3,
                      Category = "Family",
                      Title = "The Emperor's New Groove",
                      Year = 2000,
                      Director = "Mark Dindal",
                      Rating = "G",
                      Edited = false,
                      Lent = "",
                      Notes = ""
                  }
                );
        }
    }
}
