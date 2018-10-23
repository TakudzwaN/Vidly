using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context; // 1. field

        public MoviesController() // 2. constructor and initialize private fieldin 1.
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) //3. Dispose the DB _context when done with it
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .ToList();

            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit (int id)
        {
            return Content("id" + id);
        }
    }
}