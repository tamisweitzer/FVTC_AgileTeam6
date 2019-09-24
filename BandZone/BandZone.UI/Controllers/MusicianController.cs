using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BandZone.BL;

namespace BandZone.UI.Controllers
{
    public class MusicianController : Controller
    {
        MusicianList musicians;

        // GET: Musician
        public ActionResult Index()
        {
            musicians = new MusicianList();
            musicians.Load();

            return View(musicians);
        }
    }
}