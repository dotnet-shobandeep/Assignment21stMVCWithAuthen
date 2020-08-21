using MovieCustomerMvcAppWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var movies = _context1.Movies.ToList();
            return View(movies);
        }
    }
}