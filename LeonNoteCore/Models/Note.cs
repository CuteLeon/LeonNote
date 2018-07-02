using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeonNoteCore.Models
{
    public class Note
    {

        [DisplayName("笔记ID")]
        public int Id { get; set; }

        [DisplayName("标题"), Required]
        public string Title { get; set; }

        [DisplayName("内容"), Required]
        public string Content { get; set; }

        [DisplayName("发布时间"), Required, DataType(DataType.DateTime)]
        public DateTime? PublishTime { get; set; }

        [DisplayName("是否被删除"), Required]
        public bool Deleted { get; set; }

        [DisplayName("发布者ID")]
        public int UserID { get; set; }

        [DisplayName("用户")]
        public virtual User User { get; set; }
    }
}
