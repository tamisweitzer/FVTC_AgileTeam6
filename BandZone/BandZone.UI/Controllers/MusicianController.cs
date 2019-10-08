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

        // GET: Musician/Create
        public ActionResult Create()
        {
            Musician customer = new Musician();
            return View(customer);
        }



        // POST: Musician/Create
        [HttpPost]
        public ActionResult Create(Musician musician)
        {
            try
            {
                musician.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(musician);
            }
        }



       
        

    }
}


    
    