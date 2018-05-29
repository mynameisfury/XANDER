using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XANDER.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("Client"))
            {
                return RedirectToAction("ClientHome" , "Clients");
            }
            else if (User.IsInRole("Worker"))
            {
                return RedirectToAction("WorkerHome", "Workers");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult Webhook()
        //{
        //    //Handle webhook call
        //}


    }
}