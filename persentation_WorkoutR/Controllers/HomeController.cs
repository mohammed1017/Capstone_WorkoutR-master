using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace persentation_WorkoutR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My Contact";

            return View();
        }
    }
}