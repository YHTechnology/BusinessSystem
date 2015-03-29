using System.ComponentModel.DataAnnotations;

namespace BS.Entities
{
    public class Department
    {
        [Key]
        public string DepartmentName { get; set; }
    }
}
