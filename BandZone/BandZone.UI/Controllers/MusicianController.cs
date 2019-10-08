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

        // GET: Musician/Details/5
        public ActionResult Details(int id)
        {
            Musician musician = new Musician();
            musician.MusicianId = id;
            musician.LoadById();
            return View(musician);
        }

        // GET: Musician/Create
        public ActionResult Create()
        {
            Musician musician = new Musician();
            return View(musician);
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

        // GET: Musician/Edit/5
        public ActionResult Edit(int id)
        {
            Musician musician = new Musician();
            musician.MusicianId = id;
            musician.LoadById();
            return View(musician);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Musician musician)
        {
            try
            {
                // TODO: Add update logic here
                musician.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(musician);
            }
        }

        // GET: Musician/Delete/5
        public ActionResult Delete(int id)
        {
            Musician musician = new Musician();
            musician.MusicianId = id;
            musician.LoadById();
            return View(musician);
        }

        // POST: Musician/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Musician musician)
        {
            try
            {
                // TODO: Add delete logic here
                musician.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(musician);
            }
        }
    }
}
