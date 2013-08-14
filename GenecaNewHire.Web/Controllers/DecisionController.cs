using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenecaNewHire.Web.Controllers
{
    public class DecisionController : Controller
    {
        public ActionResult EndAdventure(int id)
        {
            switch (id)
            {
                case 1:
                    ViewBag.Badending = "Never, ever turn down an offer from Geneca.";
                    ViewBag.Image = "../../Content/images/toobad.jpg";
                    break;
                case 2:
                    ViewBag.Badending = "Illegal contact! 15 yard restraining order!";
                    ViewBag.Image = "../../Content/images/referee.jpg";
                    break;
                case 3:
                    ViewBag.Badending = "";
                    ViewBag.Image = "../../Content/images/toobad.jpg";
                    break;
            }

            return View();
        }

        [HttpPost]
        public ActionResult EndAdventure(FormCollection collection)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult FirstDay()
        {
            Session["Visited"] = Session["Visited"] + " => " + "First day";
            return View();
        }

        [HttpPost]
        public ActionResult FirstDay(FormCollection collection)
        {
            if (collection["ChooseOutfit"] == "0") 
            {
                return RedirectToAction("Apology", "Decision", new { id = 1 });
            }

            return RedirectToAction("Lunch");
        }

        public ActionResult Lunch()
        {
            Session["Visited"] = Session["Visited"] + " => " + "Lunch";
            return View();
        }

        [HttpPost]
        public ActionResult Lunch(FormCollection collection)
        {
            if (collection["Choose"] == "0")
            {
                return RedirectToAction("Apology", "Decision", new { id = 2 });
            }

            return RedirectToAction("MeetGreet");
        }

        public ActionResult MeetGreet()
        {
            Session["Visited"] = Session["Visited"] + " => " + "Meet Greet";

            return View();
        }

        [HttpPost]
        public ActionResult MeetGreet(FormCollection collection)
        {
            if (collection["ChooseGreeting"] == "0")
            {
                return RedirectToAction("EndAdventure", "Decision", new { id = 2 });
            }

            if (collection["ChooseGreeting"] == "1")
            {
                return RedirectToAction("Apology", "Decision", new { id = 3 });
            }

            return RedirectToAction("Slogan");
        }

        public ActionResult Apology(int id)
        {
            switch (id)
            {
                case 1:
                    ViewBag.Mistake = "You shouldn't have wore shorts. Idiot!";
                    ViewBag.Image = "../../Content/images/shorts.jpg";
                    break;
                case 2:
                    ViewBag.Mistake = "Your decision to have everyone try China Buffet makes Mike Denton sick!";
                    ViewBag.Image = "../../Content/images/sick.jpg";
                    break;
                case 3:
                    ViewBag.Mistake = "Weirdo, no one likes you!";
                    ViewBag.Image = "../../Content/images/weird.jpg";
                    break;
                case 4:
                    ViewBag.Mistake = "that slogan stinks!";
                    ViewBag.Image = "../../Content/images/badslogan.jpg";
                    break;
                case 5:
                    ViewBag.Mistake = "You didn't follow directions did you? Apologize to Mike Reyes!";
                    ViewBag.Image = "../../Content/images/school.jpg";
                    break;
            }

            Session["Visited"] = Session["Visited"] + " => " + "Apology";

            return View();
        }

        [HttpPost]
        public ActionResult Apology(int id, string btnChoose, FormCollection collection)
        {
            if (btnChoose == "No")
            {
                return RedirectToAction("EndAdventure", "Decision", new { id = 3 });
            }

            switch (id)
            {
                case 1:
                    return RedirectToAction("Lunch");
                case 2:
                    return RedirectToAction("MeetGreet");
                case 3:
                    return RedirectToAction("Slogan");
                case 4:
                    return RedirectToAction("Riddle", "Decision", new { id = 0 });
                case 5:
                    return RedirectToAction("Congrats", "Home");
            }

            return View();
        }

        public ActionResult Slogan()
        {
            Session["Visited"] = Session["Visited"] + " => " + "Slogan";

            return View();
        }

        [HttpPost]
        public ActionResult Slogan(FormCollection collection)
        {
            if (collection["Choose"] == "0")
            {
                return RedirectToAction("Apology", "Decision", new { id = 4 });
            }

            return RedirectToAction("Riddle", "Decision", new { id = 0 });
        }

        public ActionResult Riddle(int id)
        {
            if (id == 1)
            {
                ViewBag.Error = "Wrong answer, keep trying.";
            }
            else
            {
                ViewBag.Error = "";
            }

            Session["Visited"] = Session["Visited"] + " => " + "Riddle";

            return View();
        }

        public ActionResult Answer(string answer)
        {
            if (answer.ToLower() == "water")
            {
                return RedirectToAction("Congrats", "Home");
            }

            return RedirectToAction("Riddle", "Decision", new { id = 1 });
        }

        public ActionResult Offer()
        {
            Session["Visited"] = "Offer page";
            return View();
        }

        [HttpPost]
        public ActionResult Offer(string btnChoose)
        {
            switch (btnChoose)
            {
                case "Yes":
                    return RedirectToAction("FirstDay", "Decision");
                case "No":
                    return RedirectToAction("EndAdventure", "Decision", new { id = 1 });
            }

            return View();
        }
        
    }
}
