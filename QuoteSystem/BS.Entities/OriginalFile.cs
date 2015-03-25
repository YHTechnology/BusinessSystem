
using System.ComponentModel.DataAnnotations;

namespace BS.Entities
{
    // 原始文件
    public class OriginalFile
    {
        // 原始文件编号
        [Key]
        public long OriginalFileID { get; set; }

        // 原始文件名称
        public string OriginalFileName { get; set; }

        // 原始文件名
        public string OriginalFileFileName { get; set; }
    }
}
