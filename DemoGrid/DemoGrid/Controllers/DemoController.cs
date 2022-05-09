using DemoGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Data.Entity;

namespace DemoGrid.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAthletes(string searchString, string word, int? page, int? rows)
        {
        //    if (rows == null)
        //    {
        //        var jsonData = new { page = 1, total = 0, records = 0, rows =[] }};
        //    return Json{ jsonData,JsonRequestBehavior.AllowGet };
        //}
            using (DatabaseContextModel db = new DatabaseContextModel())
            {
                int? pageIndex = Convert.ToInt32(page) - 1;
                int? pageSize = rows;

                var Results = db.AthletesModel.Select(
             a => new
             {
                 a.AthleteID,
                 a.AthleteName,
                 a.Age,
                 a.Country,
                
                 a.ClosingCeremonyDate,
                 a.Sport,
                 a.GoldMedal,
                 a.SilverMedal,
                 a.BronzeMedal,
                 a.TotalMedals
             });

                int totalRecords = Results.Count();
                if(rows==null)
                {
                    rows =0;
                    page = 1;
                    totalRecords = 0;
                        int totalPages = 0;
                }
                else
                {
                    var totalPages = (int)Math.Ceiling((float)totalRecords / (int)rows);

                }



                if (word.ToUpper() == "DESC")
                {
                    Results = Results.OrderByDescending(s => s.AthleteID);
                    Results = Results.Skip(((int)pageIndex * (int)pageSize)).Take((int)pageSize);
                }
                else
                {
                    Results = Results.OrderBy(s => s.AthleteID);
                    Results = Results.Skip(((int)pageIndex * (int)pageSize)).Take((int)pageSize);
                }


                if (!string.IsNullOrEmpty(searchString))
                {
                    Results = Results.Where(m => m.AthleteName == searchString || m.Country == searchString);
                }

                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = Results
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        public JsonResult CreateAthlete([Bind(Exclude = "AthleteID")] AthletesModel Athletes)
        {
            StringBuilder msg = new StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    using (DatabaseContextModel db = new DatabaseContextModel())
                    {
                        db.AthletesModel.Add(Athletes);
                        db.SaveChanges();
                        return Json("Saved Successfully", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var errorList = (from item in ModelState
                                     where item.Value.Errors.Any()
                                     select item.Value.Errors[0].ErrorMessage).ToList();

                    return Json(errorList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var errormessage = "Error occured: " + ex.Message;
                return Json(errormessage, JsonRequestBehavior.AllowGet);
            }

        }

        public string EditAthlete(AthletesModel Athletes)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    using (DatabaseContextModel db = new DatabaseContextModel())
                    {
                        db.Entry(Athletes).State = EntityState.Modified;
                        db.SaveChanges();
                        msg = "Saved Successfully";
                    }
                }
                else
                {
                    msg = "Some Validation ";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string DeleteAthlete(int? Id)
        {
            using (DatabaseContextModel db = new DatabaseContextModel())
            {
                AthletesModel Athletes = db.AthletesModel.Find(Id);
                db.AthletesModel.Remove(Athletes);
                db.SaveChanges();
                return "Deleted successfully";
            }
        }


    }
}