using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Configuration;
using coffeeshop.Models;
using System.Web.Security;

namespace coffeeshop.Controllers
{
    public class UserController : Controller
    {
        //Register
        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Register(User userModel)
        {
            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.Users.Any(x => x.UserName == userModel.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("Register", userModel);
                }
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("Register", new User());
        }

        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin userloginModel)
        {
            using (DbModels dbmodel = new DbModels())
            {
                var v = dbmodel.Users.Where(x => x.UserName == userloginModel.UserName).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(userloginModel.Password, v.Password) == 0)
                    {
                        if(v.IsAdmin)
                        {
                            return RedirectToAction("AdminHomePage", "Admin", userloginModel);
                        }
                        else
                        {
                            return View("UserHomePage", userloginModel);

                        }
                    }
                    else
                    {
                        ModelState.Clear();
                        ViewBag.DangerMessage = "Password is Incorrect, Please try again";
                        return View("Login", userloginModel);
                    }
                }
                ViewBag.DangerMessage = "User not found, Please Register";
                return View("Register", new User());
            }
        }

        //Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");

        }

        //UserHomePage
        [HttpGet]
        public ActionResult UserHomePage(UserLogin userLogin)
        {
            return View(userLogin);
        }

        [HttpGet]
        public ActionResult Order()
        {
            return RedirectToAction("ChooseTable", "Table");
        }


    }
}