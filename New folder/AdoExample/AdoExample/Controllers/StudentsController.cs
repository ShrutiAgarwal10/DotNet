﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using AdoExample.Models;

namespace AdoExample.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult Save(Student student)
        {
            string status = "";
            // Creating Connection  
            using (SqlConnection con = new SqlConnection("data source=.; database=student; integrated security=SSPI"))
            {
                // Insert query  
                string query = "INSERT INTO student(name,email,contact) VALUES(@name, @email, @contact)";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    // opening connection  
                    con.Open();
                    // Passing parameter values  
                    cmd.Parameters.AddWithValue("@name", student.Name);
                    cmd.Parameters.AddWithValue("@email", student.Email);
                    cmd.Parameters.AddWithValue("@contact", student.Contact);
                    // Executing insert query  
                    status = (cmd.ExecuteNonQuery() >= 1) ? "Record is saved Successfully!" : "Record is not saved";
                    status += "<br/>";
                }
                // Executing select command  
                using (SqlCommand cmd = new SqlCommand("select * from student"))
                {
                    cmd.Connection = con;
                    // Retrieving Record from datasource  
                    SqlDataReader sdr = cmd.ExecuteReader();
                    // Reading and Iterating Records  
                    while (sdr.Read())
                    {
                        status += "<b>name:</b> " + sdr["name"] + "<br/> <b>Email:</b> " + sdr["email"] + "<br> <b>Contact:</b> " + sdr["contact"];
                    }
                }
                return Content(status);
            }
        }
    }
}


