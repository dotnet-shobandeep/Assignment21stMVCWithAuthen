using MovieCustomerMvcAppWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCustomerMvcAppWithAuthentication.ViewModel
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> GenreType { get; set; }
        public Movie Movie { get; set; }
    }
}