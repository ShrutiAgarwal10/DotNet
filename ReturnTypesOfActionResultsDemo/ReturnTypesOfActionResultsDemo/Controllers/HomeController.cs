using ReturnTypesOfActionResultsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReturnTypesOfActionResultsDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string Message= "Your contact page.")
        {
            ViewBag.Message = Message;


            return View();
        }

        

        public ContentResult GreetUser()
        {
            return Content("Hello from content result greetuser");
        }

        public ViewResult WishUser()
        {
            return View();
        }
        public RedirectResult GoToURL()
        {
            return Redirect("https://www.google.com");
        }
        
        //public RedirectResult GoToURLPer()
        //{
        //    return RedirectPermanent("https://www.unthinkable.co/");
        //}
        public RedirectResult GoToURLPerm()
        {
            return RedirectPermanent("https://www.google.com/");
        }
        public RedirectToRouteResult GoToContact()
        {
            return RedirectToAction("Contact", new { Message = "Hello from GoToContact" });
        }

        public RedirectToRouteResult GoToAbout()
        {
             return RedirectToRoute("AboutUs");
        }

        public FileResult ShowCSSContent()
        {
            return File(Server.MapPath("~/Content/Site.css"), "text/css");
        }

        //public FileResult ShowPoducts()
        //{
        //    return File(Server.MapPath("~/Content/Site.css"))
        //}

        public JsonResult ShowAllProducts()
        {
            Products prod = new Products() { ProductName = "Printer", Cost = 4000, ProductCode = 101 };
            return Json(prod, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult ShowChildViewContent()
        {
            return PartialView();
        }

    }
}