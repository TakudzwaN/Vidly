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

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
               
                Genres = genre
            };
            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("New", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
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
       
        public ActionResult Edit (int id)
        {
            var movie = _context.Movies
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genres.ToList()
            };
            return View("Edit", viewModel);
        }
    }
}