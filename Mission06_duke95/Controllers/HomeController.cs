using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_duke95.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_duke95.Controllers
{
    public class HomeController : Controller
    {
        
        private MovieContext StoreContext { get; set; }

        public HomeController(MovieContext TempContext)
        {
            StoreContext = TempContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Redirecting to baconsale website
        public IActionResult MyPodcasts()
        {
            return RedirectPermanent("https://baconsale.com/");
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = StoreContext.Categories.ToList();

            return View();
        }
        [HttpPost]
        // Validate Add Movie model
        public IActionResult AddMovie(AddMovieResponse amr)
        {
            if (ModelState.IsValid)
            {
                StoreContext.Add(amr);
                StoreContext.SaveChanges();
                return View("Index", amr);
            }
            else
            {
                ViewBag.Categories = StoreContext.Categories.ToList();

                return View();
            }
        }
        // Create MovieList page
       public IActionResult MovieList()
        {
            var MovieForm = StoreContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(MovieForm);
        }
        // Edit MovieList
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = StoreContext.Categories.ToList();

            var MovieForm = StoreContext.Responses.Single(x => x.MovieId == movieid);

            return View("AddMovie", MovieForm);
        }

        [HttpPost]
        public IActionResult Edit(AddMovieResponse changes)
        {
            StoreContext.Update(changes);
            StoreContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var MovieForm = StoreContext.Responses.Single(x => x.MovieId == movieid);

            return View(MovieForm);
        }

        [HttpPost]
        public IActionResult Delete(AddMovieResponse deletion)
        {
            StoreContext.Responses.Remove(deletion);
            StoreContext.SaveChanges();

            return RedirectToAction("MovieList");
        }







    }
}
