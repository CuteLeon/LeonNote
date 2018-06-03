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
            Session["User"] = noteDB.UserBase.First(u => u.UserName == "Mathilda");

            if (Session["User"] == null) return View();
            int UserID = (Session["User"] as User).Id;
            var notes = noteDB.NoteBase
                .Where(note => note.UserID == UserID)
                .ToList();
            return View(notes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}