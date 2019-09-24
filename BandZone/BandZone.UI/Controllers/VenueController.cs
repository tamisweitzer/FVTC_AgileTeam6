using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// add using statement to model

namespace BandZone.UI.Controllers
{
    public class VenueController : Controller
    {
        // GET: Venue
        public ActionResult Index()
        {
            ViewBag.Message = "Venue page";
            return View();
        }
    }
}