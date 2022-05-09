using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;



namespace DemoGrid.Models
{
    public class DatabaseContextModel : DbContext 
    {
        public DatabaseContextModel() : base("DBConnection")
        {
        }
        public DbSet<AthletesModel> AthletesModel { get; set; }
    }
}