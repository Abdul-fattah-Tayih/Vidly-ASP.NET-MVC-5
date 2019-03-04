using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;
using WebAppMVC.ViewModels;
using System.Data.Entity;

namespace WebAppMVC.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var mov = new MovieFormViewModel
            {
                Genre = GetGenres()
            };
            return View("MovieForm", mov);
        }

        public ActionResult Edit(int id)
        {
            var mov = _context.Movies.ToList().Single(x => x.id == id);
            if (mov == null)
                HttpNotFound();
            var viewMod = new MovieFormViewModel
            {
                Movie = mov,
                Genre = GetGenres()
            };
            return View("MovieForm", viewMod);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            //check if validation failed, reload the form
            if(!ModelState.IsValid)
            {
                var viewMod = new MovieFormViewModel
                {
                    Movie = movie,
                    Genre = GetGenres()
                };
                return View("MovieForm", viewMod);
            }
            //if id == 0 which is the default if the object doesn't exists in the DB, insert it into DB
            if (movie.id == 0)
            {
                movie.dateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            //else update the existing record using the id
            else
            {
                var MovieInDB = GetSingleMovie(movie.id);
                MovieInDB.name = movie.name;
                MovieInDB.releaseDate = movie.releaseDate;
                MovieInDB.dateAdded = movie.dateAdded;
                MovieInDB.genreId = movie.genreId;
                MovieInDB.noInStock = movie.noInStock;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Index()
        {
            return View(GetMovies());
        }

        public Movie GetSingleMovie(int id)
        {
            return GetMovies().Single(x => x.id == id);
        }
        public List<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.genre).ToList();
        }
        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}