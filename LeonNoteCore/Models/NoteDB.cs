using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeonNoteCore.Models
{
    public class NoteDB : DbContext
    {
        public DbSet<User> UserBase { get; set; }

        public DbSet<Note> NoteBase { get; set; }

        private static bool _created = false;
        public NoteDB()
        {
            if (!_created)
            {
                _created = true;
                //数据库不存在则创建
                Database.EnsureCreated();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //表不存在时，自动创建数据表
            modelBuilder.Entity<Note>().ToTable("NoteBase");
            modelBuilder.Entity<User>().ToTable("UserBase");

            //种子数据：(注意 : ID 从1开始)
            modelBuilder.Entity<User>().HasData(new User[] {
                new User(){ Id = 1, UserName = "Leon", Password="IamLeon" },
                new User(){ Id = 2, UserName = "Mathilda", Password="IamMathilda" },
            });

            modelBuilder.Entity<Note>().HasData(new Note[] {
                new Note() { Id = 1, Title = "测试笔记-1",PublishTime= DateTime.Now, Content = "测试笔记-1", UserID = 1 },
                new Note() { Id = 2, Title = "测试笔记-2",PublishTime= DateTime.Now, Content = "测试笔记-2", UserID = 1 },
                new Note() { Id = 3, Title = "测试笔记-3",PublishTime= DateTime.Now, Content = "测试笔记-3", UserID = 1 },
                new Note() { Id = 4, Title = "测试笔记-4",PublishTime= DateTime.Now, Content = "测试笔记-4", UserID = 2 },
                new Note() { Id = 5, Title = "测试笔记-5",PublishTime= DateTime.Now, Content = "测试笔记-5", UserID = 2 },
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            //懒惰加载代理
            /* 一个问题：
             * 使用dotnet命令直接运行dll：数据库创建在dll同目录
             * 而是用VS调试时，数据库会创建在项目目录内，即与bin文件夹同级
             */
            optionbuilder.UseLazyLoadingProxies().UseSqlite($"Data Source=NoteDB.db");
        }
    }
}
