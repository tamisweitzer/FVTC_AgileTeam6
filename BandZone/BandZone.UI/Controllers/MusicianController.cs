using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BandZone.BL;
using BandZone.UI.Model;
using BandZone.UI.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BandZone.UI.Controllers
{
    public class MusicianController : Controller
    {

        MusicianList musicians;
        //MusicGenreModel mgm = new MusicGenreModel();

        

        // GET: Musician
        public ActionResult Index(string searchString, string musicGenre, string sortOrder, int? input_genre)
        {
            MusicGenreModel mgm = new MusicGenreModel();
            musicians = new MusicianList();
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            IEnumerable<Musician> filteredMusicians;

            if (searchString == null)
            {
                musicians.LoadMusician();

                switch (sortOrder)
                {
                    case "name_desc":
                        filteredMusicians = musicians.OrderByDescending(m => m.BandMusicianName);
                        break;
                    default:
                        filteredMusicians = musicians.OrderBy(m => m.BandMusicianName);
                        break;
                }

                return View(filteredMusicians);
            }
            else
            {
                if (input_genre.HasValue)
                {
                    MusicianList musician = new MusicianList();
                    musician.Load(input_genre.Value);
                    ViewBag.GenreId = input_genre.Value;
                    filteredMusicians = musician.Where(m => m.BandMusicianName.ToLower().Contains(searchString.ToLower())).Distinct();

                    switch (sortOrder)
                    {
                        case "name_desc":
                            filteredMusicians = filteredMusicians.OrderByDescending(m => m.BandMusicianName);
                            break;
                        default:
                            filteredMusicians = filteredMusicians.OrderBy(m => m.BandMusicianName);
                            break;
                    }

                    return View("Index", filteredMusicians);
                }
                else
                {
                    musicians.LoadMusician();
                    filteredMusicians = musicians.Where(m => m.BandMusicianName.ToLower().Contains(searchString.ToLower()));

                    switch (sortOrder)
                    {
                        case "name_desc":
                            filteredMusicians = filteredMusicians.OrderByDescending(m => m.BandMusicianName);
                            break;
                        default:
                            filteredMusicians = filteredMusicians.OrderBy(m => m.BandMusicianName);
                            break;
                    }

                    return View(filteredMusicians);
                }
            }
        }

        public ActionResult Load(int id)
        {
            MusicianList musician = new MusicianList();
            musician.Load(id);
            ViewBag.GenreId = id;
            return View("Index", musician);
        }


        //Added 12/02 - Brings the Genre info (model)
        // GET: Musician/Details/5
        public ActionResult Details(int id)
        {
            if (MusicianAuthenticate.IsAuthenticated())
            {

                MusicGenreModel mgm = new MusicGenreModel();

                mgm.Musician = new Musician();
                mgm.Musician.MusicianId = id;
                mgm.Musician.LoadById();

                // load all genres
                mgm.Genres = new GenreList();
                mgm.Genres.Load();

                //deal wtith the existing genres 
                IEnumerable<int> existingGenresIds = new List<int>();

                //select only the Ids
                existingGenresIds = mgm.Musician.Genres.Select(a => a.GenreId);
                mgm.GenreIds = existingGenresIds;

                Session["genreids"] = existingGenresIds;

                return View(mgm);
            }
            else
            {
                return RedirectToAction("Create", "MusicianLogin", "Index");
            }
            
        }

        // GET: Musician/Details/5
        //public ActionResult Details(int id)
        //{
        //if (MusicianAuthenticate.IsAuthenticated())
        //{
        //Musician musician = new Musician();
        //musician.MusicianId = id;
        //musician.LoadById();
        //return View(musician);
        //}
        //else
        //{
        //  return RedirectToAction("Create", "MusicianLogin");
        //}
        //}


        // GET: Musician/Create
        public ActionResult Create()
        {
            MusicGenreModel mgm = new MusicGenreModel();

            Musician musician = new Musician();
            mgm.Musician = musician;

            mgm.Genres = new GenreList();
            mgm.Genres.Load();

            return View(mgm);
        }



        // POST: Musician/Create
        [HttpPost]
        public ActionResult Create(MusicGenreModel mgm)
        {
            try
            {
                mgm.Musician.Insert();
                int id = mgm.Musician.MusicianId;
                mgm.GenreIds.ToList().ForEach(a => MusicGenre.Add(id, a));
                return RedirectToAction("Index");
            }
            catch
            {
                return View(mgm);
            }
        }




        // GET: Musician/Edit/5
        public ActionResult Edit(int id)
        {
            MusicGenreModel mgm = new MusicGenreModel();

            if (MusicianAuthenticate.IsAuthenticated())
            {
                mgm.Musician = new Musician();
                mgm.Musician.MusicianId = id;
                mgm.Musician.LoadById();

                // load all genres
                mgm.Genres = new GenreList();
                mgm.Genres.Load();

                //deal wtith the existing genres 
                IEnumerable<int> existingGenresIds = new List<int>();

                //select only the Ids
                existingGenresIds = mgm.Musician.Genres.Select(a => a.GenreId);
                mgm.GenreIds = existingGenresIds;

                Session["genreids"] = existingGenresIds;

                return View(mgm);
            }
            else
            {
                //return RedirectToAction("Create", "Login", new { returnurl = HttpContext.Request.Url});
                return RedirectToAction("Create", "MusicianLogin", "Index");
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MusicGenreModel mgmedit)
        {
            try
            {
                //Deal with the genres (add, delete)
                IEnumerable<int> oldgenreIds = new List<int>();
                if (Session["genreids"] != null)
                    oldgenreIds = (IEnumerable<int>)Session["genreids"];

                IEnumerable<int> newgenreids = new List<int>();
                if (mgmedit.GenreIds != null)
                    newgenreids = mgmedit.GenreIds;

                //Identify the deletes (the old ones that aren't on the new ones)
                IEnumerable<int> deletes = oldgenreIds.Except(newgenreids);

                //identify the adds
                IEnumerable<int> adds = newgenreids.Except(oldgenreIds);

                //Do the deletes
                deletes.ToList().ForEach(d => MusicGenre.Delete(id, d));

                //Do the adds
                adds.ToList().ForEach(a => MusicGenre.Add(id, a));

                // TODO: Add update logic here
                mgmedit.Musician.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(mgmedit);
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
                musician.MusicianId = id;
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
