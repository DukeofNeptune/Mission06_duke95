using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieContext StoreContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext TempContext)
        {
            _logger = logger;
            StoreContext = TempContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return RedirectPermanent("https://baconsale.com/");
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(AddMovieResponse amr)
        {
            StoreContext.Add(amr);
            StoreContext.SaveChanges();
            return View("Index", amr);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
