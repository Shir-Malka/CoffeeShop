using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using coffeeshop.Models;
using System.Configuration;
using System.Web.Security;

namespace coffeeshop.Controllers
{
    public class AdminController : Controller
    {

        //Login
        [HttpGet]
        public ActionResult AdminHomePage(UserLogin userLogin)
        {
            return View(userLogin);
        }

        //Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");

        }

    }

}