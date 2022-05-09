using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomActionFiltersDemo.Controllers
{
    //[MyCustomActionFilter]
    public class HomeController : Controller
    {
        [MyCustomActionFilter(Order=2)]
        [MyNewCustomActionFilter(Order =1)]
        public ActionResult Index()
        {
            return View();
        }

        //[MyCustomActionFilter]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //[MyCustomActionFilter]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}