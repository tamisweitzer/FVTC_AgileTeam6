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
            HttpContext.Session["user"] = null;
            return View();
        }


        // Create an account
        public ActionResult Create(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        [HttpPost]
        public ActionResult Create ( Musician musician, string returnurl )
        {
            try
            {
                if (musician.Login())
                {
                    HttpContext.Session["musician"] = musician;
                    if (returnurl == null) {
                        ViewBag.Message = "login worked";
                        return RedirectToAction("Index", "Musician");
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