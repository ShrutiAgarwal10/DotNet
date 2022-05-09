using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register(int id=0)
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            using(DBModels db = new DBModels())
            {
                if(db.Users.Any(x=>x.UserName==user.UserName))
                {
                    ViewBag.DuplicateMessage = "UserName already exists. Choose another.";
                    return View("Register", user);
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
               
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            return View("Register", new User());
        }

        
    }
}