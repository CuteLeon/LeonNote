using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeonNote.Models;

namespace LeonNote.Controllers
{
    public class HomeController : Controller
    {
        NoteDB noteDB = new NoteDB();

        public ActionResult Index()
        {
            //TODO: 自动登录调试代码；
            //Session["User"] = noteDB.UserBase.First(u => u.UserName == "Leon");

            if (Session["User"] == null) return View(new List<Note>());
            int UserID = (Session["User"] as User).Id;
            var notes = noteDB.NoteBase
                .Where(note => note.UserID == UserID)
                .ToList();
            return View(notes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "欢迎访问我第一个 ASP.NET MVC 程序";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Leon.ID@QQ.COM";

            return View();
        }

    }
}