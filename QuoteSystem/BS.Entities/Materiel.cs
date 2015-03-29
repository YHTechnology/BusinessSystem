
using System.ComponentModel.DataAnnotations;

namespace BS.Entities
{
    // 物料表
    public class Materiel
    {
        // 物料编号
        [Key]
        public string MaterielID { get; set; } 

        // 物料名称
        public string MaterielName { get; set; }

        // 物料查询名称
        public string MaterielSearchName { get; set; }

        // 物料描述
        public string MeterieDescription { get; set; } 

        // 单位
        public string Unit { get; set; }

        // 品牌
        public string Brand { get; set; }

        // 不含税单价
        public decimal Price { get; set; }
    }
}
