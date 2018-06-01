using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace LeonNote.Models
{
    public class SampleData : DropCreateDatabaseAlways<NoteDB>
    {
        protected override void Seed(NoteDB context)
        {
            context.UserBase.Add(
                new User()
                {
                    UserName = "Leon",
                    Password = "IamLeon",
                    Notes = new List<Note>
                    {
                        new Note(){ Title="ASP.NET开发学习" , Content="今天要开始学习ASP.NET开发。", PublishTime=DateTime.Now},
                        new Note(){ Title="节日快乐！" , Content="六一儿童节了，想去二七逛街，和我的小小冰糖~", PublishTime=DateTime.Now},
                    }
                });

            context.UserBase.Add(
                new User()
                {
                    UserName = "Mathild",
                    Password = "IamMathilda",
                    Notes = new List<Note>
                    {
                        new Note(){ Title="过六一咯" , Content="今天是六一儿童节，和大叔一起去二七逛时尚的gai~啦啦啦~~~", PublishTime=DateTime.Now},
                    }
                });

            base.Seed(context);
        }
    }
}