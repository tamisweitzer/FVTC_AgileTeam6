using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BandZone.BL;

namespace BandZone.UI.Controllers
{
    public class VenueController : Controller
    {
        VenueList venues;

        // GET: Venue
        public ActionResult Index()
        {
            venues = new VenueList();
            venues.Load();
            return View(venues);
        }

        // GET: Venue/Details/5
        public ActionResult Details(int id)
        {
            Venue venue = new Venue();
            venue.VenueId = id;
            venue.LoadById();
            return View(venue);
        }

        // GET: Venue/Create
        public ActionResult Create()
        {
            Venue venue = new Venue();
            return View(venue);
        }

        // POST: Venue/Create
        [HttpPost]
        public ActionResult Create(Venue venue)
        {
            try
            {
                // TODO: Add insert logic here
                venue.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(venue);
            }
        }

        // GET: Venue/Edit/5
        public ActionResult Edit(int id)
        {
            Venue venue = new Venue();
            venue.VenueId = id;
            venue.LoadById();
            return View(venue);
        }

        // POST: Venue/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Venue venue)
        {
            try
            {
                // TODO: Add update logic here
                venue.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(venue);
            }
        }

        // GET: Venue/Delete/5
        public ActionResult Delete(int id)
        {
            Venue venue = new Venue();
            venue.VenueId = id;
            venue.LoadById();
            return View(venue);
        }

        // POST: Venue/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Venue venue)
        {
            try
            {
                // TODO: Add delete logic here
                venue.VenueId = id;
                venue.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(venue);
            }
        }
    }
}