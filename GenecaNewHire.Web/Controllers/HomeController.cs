using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenecaNewHire.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Session["Visited"] = "Home page";
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            return RedirectToAction("Offer", "Decision");             
        }

        public ActionResult Congrats()
        {
            Session["Visited"] = Session["Visited"] + " => " + "Congrats";

            ViewBag.Visited = Session["Visited"];

            return View();
        }
    }
}
