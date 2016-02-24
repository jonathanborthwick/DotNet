using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TOP.Controllers
{
    public class TOPController : Controller
    {

        public String testString = "";

        public ActionResult Index()
        {
            ViewBag.Message = "Traffic Obstruction Permit : Request to Proceed";

            return View();
        }

        public ActionResult Main()
        {
            ViewBag.Message = "Traffic Obstruction Permit : Request to Proceed";

            return View();
        }


    }
}
