using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BandZone.BL;

namespace BandZone.UI.Controllers
{
    public class GenreController : Controller
    {
        GenreList genres;

        // GET: Genre
        public ActionResult Index()
        {
            genres = new GenreList();
            genres.Load();
            ViewBag.Source = "Index";
            return View(genres);
        }

        [ChildActionOnly]
        public ActionResult Sidebar()
        {
            genres = new GenreList();
            genres.Load();
            return PartialView(genres);
        }
    }
}