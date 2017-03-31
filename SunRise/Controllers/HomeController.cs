using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SunRise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OurWork()
        {
           

            return View("_OurWork");
        }

        public ActionResult Contact()
        {
           

            return View("_Contact");
        }

        public ActionResult Projects()
        {
          

            return View("_Projects");
        }

        public ActionResult Testimonials()
        {
          

            return View("_Testimonials");
        }
    }
}