using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BandZone.BL;


namespace BandZone.UI.Controllers
{
    public class LoginController : Controller
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
        // ? Remove this? We have a create account action in the Musician and Venue
        public ActionResult Create(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        
    }
}