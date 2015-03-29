using System.ComponentModel.DataAnnotations;

namespace BS.Entities
{
    public class User
    {
        [Key]
        public string UserName { get; set; }

        public string UserCName { get; set; }

        public string Department { get; set; }

        public string Group { get; set; }
    }
}
