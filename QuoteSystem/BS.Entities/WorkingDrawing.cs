using System.ComponentModel.DataAnnotations;

namespace BS.Entities
{
    // 施工图
    public class WorkingDrawing
    {
        // 施工图编号
        [Key]
        public long WorkingDrawingID { get; set; }

        // 施工图名称
        public string WorkingDrawingName { get; set; }

        // 施工图文件名
        public string WorkingDrawingFileName { get; set; }
    }
}
