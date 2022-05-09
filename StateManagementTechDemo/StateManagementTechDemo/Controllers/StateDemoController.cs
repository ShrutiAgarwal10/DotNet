using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagementTechDemo.Controllers
{
    public class StateDemoController : Controller
    {
        // GET: StateDemo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StateManagementDemo()
        {
            ViewData["ECode"] = 101;

            ViewBag.EName = "Shruti";

            TempData.Add("Country", "India");

            TempData.Keep();

            return View();
        }

        [HttpPost]
        public ActionResult StateManagementDemo(FormCollection Col)
        {

            TempData.Keep();
            return View();
        }
    }
}