using EFDemmo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 
using System.Data.Entity;

namespace EFDemmo.Controllers
{
    public class EmployeeController : Controller
    {
        EFDemmoWithMVCEntities db = new EFDemmoWithMVCEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var EmployeeTables = db.EmployeeTables.Include(e => e.DepartmentTable);
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
                if(ModelState.IsValid)
                {
                    db.EmployeeTables.Add(employeeTable);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if(employeeTable==null)
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
                if(ModelState.IsValid)
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