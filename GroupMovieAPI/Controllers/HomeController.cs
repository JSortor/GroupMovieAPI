using GroupMovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupMovieAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowMovies()
        {
            ViewBag.Movies = Session["ShowMovies"];
            return View();
        }

        public ActionResult Search(string UserInput)
        {
            List<MovieDB> SearchedMovies = MovieDAL.SearchMovies(UserInput);
            Session["ShowMovies"] = SearchedMovies;

            return RedirectToAction("ShowMovies");
        }


    }
}