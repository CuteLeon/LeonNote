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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Remove()
        {
            int id =Convert.ToInt32(Request.QueryString["id"]);
            int userid = Convert.ToInt32(Request.QueryString["userid"]);
            if (userid != (Session["User"] as User).Id)
            {
                //弹窗同时后退一步
                return Content("<script>alert('非法的用户请求');history.go(-1);</script>");
            }
            noteDB.NoteBase.Remove(noteDB.NoteBase.FirstOrDefault(n => n.Id == id && n.UserID == userid));
            noteDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}