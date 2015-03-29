using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Entities
{
    // 部件
    public class Component
    {
        // 部件编号
        public string ComponentID { get; set; }

        // 部件名称
        public string ComponentName { get; set; }

        // 部件寻名称
        public string ComponentSearchName { get; set; }

        // 单位
        public string Unit { get; set; }

        // 技术协议
        public virtual ICollection<TechnicalProtocol> TechnicalProtocols { get; set; }

        // 材料清单
        public virtual ICollection<ComponentMateriels> Materiels { get; set; }

        // 施工图
        public virtual ICollection<WorkingDrawing> WorkingDrawings { get; set; }
    }
}
