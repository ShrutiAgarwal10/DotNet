using EFDemmo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFDemmo.DAL
{
    public class DepartmentDAL
    {
        private EFDemmoWithMVCEntities db = new EFDemmoWithMVCEntities();

        public IEnumerable<DepartmentTable>GetAllDepartments()
        {
            return db.DepartmentTables;
        }
    }

    
}