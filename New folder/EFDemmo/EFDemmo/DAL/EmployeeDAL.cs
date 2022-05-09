using EFDemmo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFDemmo.DAL
{
    public class EmployeeDAL
    {
        private EFDemmoWithMVCEntities db = new EFDemmoWithMVCEntities();

        public EmployeeTable GetDetails(int id)
        {
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            return employeeTable;
        }

        public IEnumerable<EmployeeTable>GetAllEmployeeTables()
        {
            return db.EmployeeTables.Include("Department");
        }

        public EmployeeTable Insert(EmployeeTable emp)
        {
            db.EmployeeTables.Add(emp);
            db.SaveChanges();
            return emp;
        }

        public void Update(EmployeeTable emp)
        {
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            db.EmployeeTables.Remove(employeeTable);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}