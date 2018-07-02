using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeonNoteCore.Models;

namespace LeonNoteCore.Controllers
{
    public class NoteController : Controller
    {
        NoteDB noteDB = new NoteDB();

        public ActionResult Remove()
        {
            if (HttpContext.Session.Get<User>("User") == null)
                return RedirectToAction("Login", "Account");
            User user = HttpContext.Session.Get<User>("User");
            int? id = Convert.ToInt32(Request.Query["id"]);
            if (id == null)
            {
                //弹窗同时后退一步
                return Content("<script>alert('无效的用户请求');history.go(-1);</script>");
            }
            //noteDB.NoteBase.Remove(noteDB.NoteBase.FirstOrDefault(n => n.Id == id && n.UserID == user.Id));
            noteDB.NoteBase.FirstOrDefault(n => n.Id == id && n.UserID == user.Id).Deleted = true;
            noteDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Publish()
        {
            if (HttpContext.Session.Get<User>("User") == null)
                return RedirectToAction("Login", "Account");
            else
                return View();
        }

        [HttpPost]
        public ActionResult Publish(Note note)
        {
            User user = HttpContext.Session.Get<User>("User");
            if (user == null)
                return RedirectToAction("Login", "Account");

            note.PublishTime = DateTime.Now;
            note.UserID = user.Id;
            noteDB.NoteBase.Add(note);
            noteDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit()
        {
            User user = HttpContext.Session.Get<User>("User");
            if (user == null)
                return RedirectToAction("Login", "Account");
            int? id = Convert.ToInt32(Request.Query["id"]);
            if (id == null)
            {
                //弹窗同时后退一步
                return Content("<script>alert('无效的用户请求');history.go(-1);</script>");
            }
            var note = noteDB.NoteBase.FirstOrDefault(n => n.Id == id && n.UserID == user.Id && !n.Deleted);
            return View(note);
        }

        [HttpPost]
        public ActionResult Edit(Note note)
        {
            User user = HttpContext.Session.Get<User>("User");
            if (user == null)
                return RedirectToAction("Login", "Account");
            int? id = Convert.ToInt32(Request.Query["id"]);
            if (id == null)
            {
                //弹窗同时后退一步
                return Content("<script>alert('无效的用户请求');history.go(-1);</script>");
            }
            var ExistedNote = noteDB.NoteBase.FirstOrDefault(n => n.Id == id && n.UserID == user.Id && !n.Deleted);
            ExistedNote.Title = note.Title;
            ExistedNote.Content = note.Content;
            noteDB.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Detail()
        {
            User user = HttpContext.Session.Get<User>("User");
            if (user == null)
                return RedirectToAction("Login", "Account");
            int? id = Convert.ToInt32(Request.Query["id"]);
            if (id == null)
            {
                //弹窗同时后退一步
                return Content("<script>alert('无效的用户请求');history.go(-1);</script>");
            }
            var ExistedNote = noteDB.NoteBase.FirstOrDefault(n => n.Id == id && n.UserID == user.Id && !n.Deleted);
            return View(ExistedNote);
        }
    }
}