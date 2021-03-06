﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeonNoteCore.Models;

namespace LeonNoteCore.Controllers
{
    public class AccountController : Controller
    {
        NoteDB noteDB = new NoteDB();

        public ActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var ExistedUser = noteDB.UserBase.FirstOrDefault<User>(m => m.UserName == user.UserName && m.Password == user.Password);
            if (ExistedUser != null)
            {
                HttpContext.Session.Set("User", ExistedUser);// 这里不要直接取 user,窦泽取不到 User.Id
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "用户名或密码错误。");
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("","用户名和密码不允许为空");
                return View(user);
            }

            var item = noteDB.UserBase.FirstOrDefault<User>(m => m.UserName == user.UserName);
            if (item != null)
            {
                ModelState.AddModelError("", "用户名已经存在，无法注册。");
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