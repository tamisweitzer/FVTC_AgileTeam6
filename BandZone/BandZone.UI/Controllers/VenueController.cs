using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BandZone.BL;
using BandZone.UI.Model;

namespace BandZone.UI.Controllers
{
    public class VenueController : Controller
    {
        VenueList venues;

        // GET: Venue
        public ActionResult Index(string searchString, string sortOrder)
        {
            venues = new VenueList();
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            IEnumerable<Venue> filteredVenues;

            if (searchString == null)
            {
                venues.Load();

                switch (sortOrder)
                {
                    case "name_desc":
                        filteredVenues = venues.OrderByDescending(m => m.VenueName);
                        break;
                    default:
                        filteredVenues = venues.OrderBy(m => m.VenueName);
                        break;
                }

                return View(filteredVenues);
            }
            else
            {
                venues.Load();

                switch (sortOrder)
                {
                    case "name_desc":
                        filteredVenues = venues.OrderByDescending(m => m.VenueName);
                        break;
                    default:
                        filteredVenues = venues.OrderBy(m => m.VenueName);
                        break;
                }

                filteredVenues = venues.Where(m => m.VenueName.ToLower().Contains(searchString.ToLower()));

                

                return View(filteredVenues);
            }
        }


        //Venue Calendar 
        [HttpGet]
        public JsonResult GetEvents(int id)
        {
            MusicianVenueEventList musicianVenueEvents = new MusicianVenueEventList();
            musicianVenueEvents.LoadVenue(id);
            var events = musicianVenueEvents.ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
            if (VenueAuthenticate.IsAuthenticated())
            {
                Venue venue = new Venue();
                venue.VenueId = id;
                venue.LoadById();
                return View(venue);
            }
            else
            {
                return RedirectToAction("Create", "MusicianLogin", new { id = id });
            }
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