using System;
using System.ComponentModel.DataAnnotations;

namespace BS.Entities
{
    // 操作
    public class Action
    {
        // 操作编号
        [Key]
        public int ActionID { get; set; }

        // 操作名称
        public string ActionName { get; set; }

        // 父操作编号
        public Nullable<int> SupperActionID { get; set; }
    }
}
