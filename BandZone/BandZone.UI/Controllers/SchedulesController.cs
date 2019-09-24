using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandZone.UI.Controllers
{
    public class SchedulesController : Controller
    {
        // GET: Schedules
        public ActionResult Index()
        {
            ViewBag.Message = "Schedules page";
            return View();
        }
    }
}