using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BandZone.BL;
using BandZone.PL;
using BandZone.UI.ViewModels;

namespace BandZone.UI.Controllers
{
    public class MusicianVenueEventController : Controller
    {
        MusicianVenueEventList musicianVenueEvents;

        // GET: Musician
        public ActionResult Index()
        {
            musicianVenueEvents = new MusicianVenueEventList();
            musicianVenueEvents.Load();

            return View(musicianVenueEvents);
        }


        public JsonResult GetEvents()
        {
            musicianVenueEvents = new MusicianVenueEventList();
            musicianVenueEvents.Load();

            var events = musicianVenueEvents.ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
        }

        // GET: Musician/Details/5
        public ActionResult Details(int id)
        {
            MusicianVenueEvent musicianVenueEvent = new MusicianVenueEvent();
            musicianVenueEvent.Id = id;
            musicianVenueEvent.LoadById();
            return View(musicianVenueEvent);
        }

        // GET: Musician/Create
        public ActionResult Create()
        {
            MusicianVenueEventModel mvem = new MusicianVenueEventModel();

            BL.MusicianVenueEvent musicianVenueEvent = new MusicianVenueEvent();
            mvem.MusicianVenueEvent = musicianVenueEvent;
            
            mvem.Musician = new MusicianList();
            mvem.Musician.Load();

            mvem.Venue = new VenueList();
            mvem.Venue.Load();

            return View(mvem);
        }



        // POST: Musician/Create
        [HttpPost]
        public ActionResult Create(MusicianVenueEventModel mvem)
        {
            try
            {
                // TODO: Add insert logic here
                mvem.MusicianVenueEvent.Insert();

                //get the id from the insert above
                int id = mvem.MusicianVenueEvent.Id;

                return RedirectToAction("Index");
            }
            catch
            {
                return View(mvem);
            }
        }



        // GET: Musician/Edit/5
        public ActionResult Edit(int id)
        {
            MusicianVenueEventModel mvem = new MusicianVenueEventModel();

            BL.MusicianVenueEvent musicianVenueEvent = new BL.MusicianVenueEvent();
            musicianVenueEvent.Id = id;
            musicianVenueEvent.LoadById();
            mvem.MusicianVenueEvent = musicianVenueEvent;

            mvem.Musician = new MusicianList();
            mvem.Musician.Load();

            mvem.Venue = new VenueList();
            mvem.Venue.Load();

            return View(mvem);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MusicianVenueEventModel mvem)
        {
            try
            {

                // TODO: Add update logic here
                mvem.MusicianVenueEvent.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(mvem);
            }
        }

        // GET: Musician/Delete/5
        public ActionResult Delete(int id)
        {
            BL.MusicianVenueEvent musicianVenueEvent = new BL.MusicianVenueEvent();
            musicianVenueEvent.Id = id;
            musicianVenueEvent.LoadById();
            return View(musicianVenueEvent);
        }

        // POST: Musician/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BL.MusicianVenueEvent musicianVenueEvent)
        {
            try
            {
                // TODO: Add delete logic here
                musicianVenueEvent.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(musicianVenueEvent);
            }
        }
    }
}
