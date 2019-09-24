using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// add using statement to BL, ViewModels, & Models
//test
namespace BandZone.UI.Controllers
{
    public class MusicianController : Controller
    {
        // GET: Musician
        public ActionResult Index()
        {
            ViewBag.Message = "Musician Page";
            return View();
            
        }
    }
}