using JqGridMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JqGridMVCProject.Controllers
{
    public class AthleteController : Controller
    {
        // GET: Athlete
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using ( DBModel db=new DBModel())
            {
                var athleteList= db.Athletes.ToList<Athlete>();
                return Json(new { rows = athleteList }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}