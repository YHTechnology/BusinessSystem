using System.ComponentModel.DataAnnotations;

namespace BS.Entities
{
    public class UserAction
    {
        [Key]
        public long UserActionID { get; set; }

        public virtual User User { get; set; }

        public virtual Action Action { get; set; }

        public bool IsPermit { get; set; }
    }
}
