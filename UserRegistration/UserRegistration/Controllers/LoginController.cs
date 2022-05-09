using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            //LoginModel lm = new LoginModel();
            //return View(lm);
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(LoginModel lm)
        //{
        //    using (DBModels db = new DBModels())
        //    {
        //        if (db.Users.Any(x => x.UserName != lm.UserName))
        //        {                    
        //            ViewBag.DuplicateMessage = "Invalid User.";
        //            return View("Login", lm);
        //        }
        //        else
        //        {
        //            if(db.Users.Any(x => x.Password != lm.Password ))
        //            {
        //                ViewBag.DuplicateMessage = "Invalid User.";
        //                return View("Login", lm);
        //            }
        //            else
        //            {
        //                ModelState.Clear();                   
        //                return RedirectToAction("details");
        //            }                             

        //        }

        //    }

        //}



        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            
            if (ModelState.IsValid)
            {

                
                var isValidUser = IsValidUser(model);

                 if (isValidUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("details");
                }
                else
                {
                    
                    ModelState.AddModelError("Failure", "Invalid User !");
                    return View();
                }
            }
            else
            {
                 return View(model);
            }
        }

        
        public User IsValidUser(LoginModel model)
        {
            using (var dataContext = new DBModels())
            {
                
               User user = dataContext.Users.Where(query => query.UserName.Equals(model.UserName) && query.Password.Equals(model.Password)).SingleOrDefault();
                
                if (user == null)
                    return null;
                
                else
                    return user;
            }
        }

        public ActionResult details()
        {
            return View();
        }
    }
}