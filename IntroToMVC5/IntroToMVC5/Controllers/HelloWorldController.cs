using IntroToMVC5.Models;
using System.Web.Mvc;

namespace IntroToMVC5.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            ViewBag.Greetings = "Hello from Unthinkable Solutions";
            ViewBag.Name = "Shruti Agarwal";
            ViewBag.Organisation = "Unthinkable Solutions";

            Authors a = new Authors();
            a.AuthorName = "author shruti";
            a.AuthorCountry = "india";


            return View(a);
        }

        public ActionResult QueryStringIndex(string Message = "Hello World")
        {
            ViewBag.Greetings = Message;
            return View();
        }

        public ActionResult GoToURL(string url = "https://unthinkable.co")
        {
            return Redirect(url);
        }
    }
}