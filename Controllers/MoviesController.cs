﻿using System;
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
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "John Smith"},
                new Customer { Name = "Mary Williams"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            //ViewData["Movie"] = movie;
            return View(viewModel);

        }
        //regex is putting constraints on the year to 4 digits and range of years 2015/2016 with the month being two digits and between 1-12
        [Route("movies/released/{year:regex(\\d{4}):range(2015,2016)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        /*
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }*/
    }
}