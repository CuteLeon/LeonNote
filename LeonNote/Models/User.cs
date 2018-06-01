using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeonNote.Models
{
    public class User
    {

        [DisplayName("用户ID")]
        public int Id { get; set; }

        [DisplayName("用户名称"),Required, DataType(DataType.Text)]
        public string UserName { get; set; }

        [DisplayName("用户密码"),Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("笔记集合")]
        public virtual List<Note> Notes { get; set; }
    }
}