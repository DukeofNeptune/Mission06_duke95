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

        public DbSet<Category> Categories { get; set; }
        //seeding data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            // Add Categories for drop down selection
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );
            mb.Entity<AddMovieResponse>().HasData(
                new AddMovieResponse
                {
                    MovieId = 1,
                    CategoryId = 1,
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
                     CategoryId = 1,
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
                      CategoryId = 4,
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
