using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAzureApp.DataAccess;
using MyAzureApp.Models;

namespace MyAzureApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext movieContext;

        public HomeController(MovieContext movieContext)
        {
            this.movieContext = movieContext;
        }

        public IActionResult Index()
        {
            var movies = movieContext.Movies.ToList();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            movieContext.Movies.Add(movie);
            movieContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
