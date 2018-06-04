using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeonNote.Models;

namespace LeonNote.Controllers
{
    public class NoteController : Controller
    {
        NoteDB noteDB = new NoteDB();

        public ActionResult Remove()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Account");
            User user = Session["User"] as User;
            int? id = Convert.ToInt32(Request.QueryString["id"]);
            if (id == null)
            {
                //弹窗同时后退一步
                return Content("<script>alert('无效的用户请求');history.go(-1);</script>");
            }
            noteDB.NoteBase.Remove(noteDB.NoteBase.FirstOrDefault(n => n.Id == id && n.UserID == user.Id));
            noteDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Publish()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Account");
            else
                return View();
        }

        [HttpPost]
        public ActionResult Publish(Note note)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Account");
            User user = Session["User"] as User;

            note.PublishTime = DateTime.Now;
            note.UserID = user.Id;
            noteDB.NoteBase.Add(note);
            noteDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Account");
            User user = Session["User"] as User;
            int? id = Convert.ToInt32(Request.QueryString["id"]);
            if (id == null)
            {
                //弹窗同时后退一步
                return Content("<script>alert('无效的用户请求');history.go(-1);</script>");
            }
            var note = noteDB.NoteBase.FirstOrDefault(n => n.Id == id && n.UserID == user.Id);
            return View(note);
        }

        [HttpPost]
        public ActionResult Edit(Note note)
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Account");
            User user = Session["User"] as User;
            int? id = Convert.ToInt32(Request.QueryString["id"]);
            if (id == null)
            {
                //弹窗同时后退一步
                return Content("<script>alert('无效的用户请求');history.go(-1);</script>");
            }
            var ExistedNote = noteDB.NoteBase.FirstOrDefault(n => n.Id == id && n.UserID == user.Id);
            ExistedNote.Title = note.Title;
            ExistedNote.Content = note.Content;
            noteDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Detail()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login", "Account");
            User user = Session["User"] as User;
            int? id = Convert.ToInt32(Request.QueryString["id"]);
            if (id == null)
            {
                //弹窗同时后退一步
                return Content("<script>alert('无效的用户请求');history.go(-1);</script>");
            }
            var ExistedNote = noteDB.NoteBase.FirstOrDefault(n => n.Id == id && n.UserID == user.Id);
            return View(ExistedNote);
        }

    }
}