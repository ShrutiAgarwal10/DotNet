using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroToMVC5.Controllers
{
    public class ShowURLElementsController : Controller
    {
        // GET: ShowURLElements
        public ActionResult Index()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];

            var message = string.Format("{0}::{1}::{2}", controller, action, id);

            ViewBag.Message = message;

            return View();
        }
    }
}