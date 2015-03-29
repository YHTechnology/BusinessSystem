using System.ComponentModel.DataAnnotations;

namespace BS.Entities
{
    public class ComponentMateriels
    {
        // 材料清单编号
        [Key]
        public long ComponentMaterielsID { get; set; }

        // 数量
        public int MeterielsCount { get; set; }

        public virtual Materiel Meteriel { get; set; }
    }
}
