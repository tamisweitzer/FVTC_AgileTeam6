using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// add using statement to model & BL

namespace BandZone.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Create()
        {
            ViewBag.Message = "Login page";
            return View();
        }

        
    }

    
}