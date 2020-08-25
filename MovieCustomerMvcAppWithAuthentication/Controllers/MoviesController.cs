using MovieCustomerMvcAppWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCustomerMvcAppWithAuthentication.ViewModel;

namespace MovieCustomerMvcAppWithAuthentication.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context1;
        public MoviesController()
        {
            _context1 = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult MovInd()
        {
            var movies = _context1.Movies.Include(g=>g.Genre).ToList();

            return View(movies);
        }
        public ActionResult Create()
        {
            var genres = _context1.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                GenreType=genres
            };
            return View(viewModel);
        }
        //[HttpPost]
        //public ActionResult Create(Movie movie)//Model Binding
        //{
        //    _context1.Movies.Add(movie);
        //    _context1.SaveChanges();
        //    return RedirectToAction("MovInd", "Movies");
        //}
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context1.Movies.Add(movie);
            else
            {
                var movieInDb = _context1.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
            }
            _context1.SaveChanges();
            return RedirectToAction("MovInd", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var updateMov = _context1.Movies.SingleOrDefault(c => c.Id == id);
            if (updateMov == null)
            {
                return HttpNotFound();
            }
            var vm = new NewMovieViewModel
            {
                Movie = updateMov,
                GenreType = _context1.Genres.ToList()
            };
            return View("Create", vm);
        }
        public ActionResult DeleteM(int id)
        {
            var movieDel = _context1.Movies.Find(id);
            _context1.Movies.Remove(movieDel);
            _context1.SaveChanges();
            return RedirectToAction("MovInd", "Movies");
        }
        public ActionResult MovDetails(int id)
        {
            var singleMovie = _context1.Movies.SingleOrDefault(c => c.Id == id);
            if (singleMovie == null)
                return HttpNotFound();
            return View(singleMovie);
        }
       
        protected override void Dispose(bool disposing)
        {
            _context1.Dispose();
        }
    }
}