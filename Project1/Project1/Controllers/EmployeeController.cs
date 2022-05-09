using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Project1.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {

        EFDemmoWithMVCEntities db = new EFDemmoWithMVCEntities();
        // GET: Employee
        //public ActionResult Index()
        //{
        //    var EmployeeTables = db.EmployeeTables.Include(e => e.DepartmentTable);
        //    return View(EmployeeTables.ToList());
        //}

        public ActionResult Index(string sortOrder)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var EmployeeTables = db.EmployeeTables.Include(e => e.DepartmentTable);

            switch (sortOrder)
            {
                case "name_desc":
                    EmployeeTables = EmployeeTables.OrderByDescending(s => s.EmployeeName);
                    break;
                case "Date":
                    EmployeeTables = EmployeeTables.OrderBy(s => s.DOJ);
                    break;
                case "date_desc":
                    EmployeeTables = EmployeeTables.OrderByDescending(s => s.DOJ);
                    break;
                default:
                    EmployeeTables = EmployeeTables.OrderBy(s => s.EmployeeName);
                    break;
            }




            //var EmployeeTables = db.EmployeeTables.Include(e => e.DepartmentTable);
            return View(EmployeeTables.ToList());
        }

        public ActionResult Details(int id)
        {
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return HttpNotFound();

            }
            return View(employeeTable);
        }

        public ActionResult Create()
        { 
            ViewBag.DeptID = new SelectList(db.DepartmentTables, "DeptId", "DeptName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeTable employeeTable)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (EFDemmoWithMVCEntities db = new EFDemmoWithMVCEntities())
                    {
                        if (db.EmployeeTables.Any(x => x.EmployeeID == employeeTable.EmployeeID))
                        {
                            string st = string.Format("Employee with ID {0} already exists", employeeTable.EmployeeID);
                            ViewBag.DuplicateMessage = st;
                            return View("Create", employeeTable);
                        }
                        else
                        {
                            db.EmployeeTables.Add(employeeTable);
                            db.SaveChanges();
                            return RedirectToAction("Index");                                                  
                        }
                    }
                }
            }

            catch(Exception e)
            {
                return View();
            }       
                return View();
        }


        public ActionResult Edit(int id)
        {
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return HttpNotFound();
            }

            ViewBag.DeptID = new SelectList(db.DepartmentTables, "DeptId", "DeptName", employeeTable.DeptID);
            return View(employeeTable);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeTable employeeTable)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(employeeTable).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

                ViewBag.DeptID = new SelectList(db.DepartmentTables, "DeptId", "DeptName", employeeTable.DeptID);
                return View(employeeTable);
            }
            catch
            {
                return View(employeeTable);
            }
        }

        public ActionResult Delete(int id)
        {
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return HttpNotFound();
            }
            return View(employeeTable);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                EmployeeTable employeeTable = db.EmployeeTables.Find(id);
                db.EmployeeTables.Remove(employeeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}