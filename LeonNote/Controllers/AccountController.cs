using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeonNote.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Login","Account");
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

    }
}