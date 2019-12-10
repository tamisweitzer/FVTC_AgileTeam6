using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BandZone.BL;


namespace BandZone.UI.Controllers
{
    public class MusicianLoginController : Controller
    {
        // GET: Login
        public ActionResult Login(string username, string password)
        {

            return View();
        }

        // Logout
        public ActionResult Logout()
        {
            HttpContext.Session["musician"] = null;
            return View();
        }


        // Create an account
        public ActionResult Create(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        [HttpPost]
        public ActionResult Create ( Musician musician, string returnurl, int id )
        {
             

            try
            {
                if (musician.Login())
                {

                    HttpContext.Session["musician"] = musician;
                    if (returnurl == null) {
                        ViewBag.Message = "login worked";
                        if ( musician.MusicianId == id )
                        {
                            return RedirectToAction("Edit", "Musician", new { id = musician.MusicianId });
                        }
                        else
                        {
                            return RedirectToAction(returnurl);
                        }
                        
                    }
                    else
                    {
                        return RedirectToAction(returnurl);
                    }
                }
                else
                {
                    ViewBag.Message = "Wrong shit, do it again";
                    return View(musician);
                }
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View(musician);
            }
        }

        
    }
}