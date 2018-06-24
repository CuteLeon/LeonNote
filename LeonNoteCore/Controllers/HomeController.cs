using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using LeonNoteCore.Models;
using Microsoft.AspNetCore.Http;

namespace LeonNoteCore.Controllers
{
    public class HomeController : Controller
    {
        NoteDB noteDB = new NoteDB();

        public IActionResult Index()
        {
            User user = HttpContext.Session.Get<User>("User");
            /*
            User user = UnityNoteDB.UserBase.FirstOrDefault(u => u.UserName == "Leon");
            HttpContext.Session.Set("User", user);
             */
            if (user == null) return View(new List<Note>());

            var notes = noteDB.NoteBase
                .Where(note => note.UserID == user.Id)
                .ToList();

            return View(notes);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
