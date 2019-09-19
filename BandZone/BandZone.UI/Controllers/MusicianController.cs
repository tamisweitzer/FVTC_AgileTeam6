using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// add using statement to BL, ViewModels, & Models

namespace BandZone.UI.Controllers
{
    public class MusicianController : Controller
    {
        // GET: Musician
        public ActionResult Index()
        {
            if (Authenticate.IsAuthenticated())
            {
                musician = new Musician();
                musician.load()
                return View();
            }
            else
            {
                return RedirectToAction("Create", "Login", new { returnurl = HttpContext.Request.Url });
            }
            
        }
    }
}