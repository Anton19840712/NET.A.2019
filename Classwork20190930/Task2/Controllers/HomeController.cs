using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        private FotoPathEntities db = new FotoPathEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View(db.SimplePathTabs.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}