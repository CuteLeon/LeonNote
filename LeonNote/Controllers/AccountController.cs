using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeonNote.Models;

namespace LeonNote.Controllers
{
    public class AccountController : Controller
    {
        NoteDB noteDB = new NoteDB();

        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Login","Account");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var item = noteDB.UserBase.FirstOrDefault<User>(m => m.UserName == user.UserName && m.Password == user.Password);
            if (item != null)
            {
                Session["User"] = user;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("","用户名或密码错误。");
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            var item = noteDB.UserBase.FirstOrDefault<User>(m => m.UserName == user.UserName);
            if (item != null)
            {
                ModelState.AddModelError("","用户名已经存在，无法注册。");
                return View(user);
            }
            else
            {
                noteDB.UserBase.Add(user);
                noteDB.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

    }
}