using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeonNote.Models
{
    public class NoteDB:DbContext
    {
        public DbSet<User> UserBase { get; set; }

        public DbSet<Note> NoteBase { get; set; }
    }
}