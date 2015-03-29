using System;
using System.ComponentModel.DataAnnotations;

namespace BS.Entities
{
    public class DepartmentAction
    {
        [Key]
        public long DepartmentActionID { get; set; }

        public virtual Component Component { get; set; }

        public virtual Action Action { get; set; }

        public Nullable<bool> IsPermit { get; set; }
    }
}
