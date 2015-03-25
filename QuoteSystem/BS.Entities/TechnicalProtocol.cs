using System.ComponentModel.DataAnnotations;

namespace BS.Entities
{
    // 技术协议   
    public class TechnicalProtocol
    {
        // 技术协议编号
        [Key]
        public long TechnicalProtocolID { get; set; }

        // 技术协议语言
        public string Language { get; set; }

        // 技术协议
        public string TechnicalProtocolDetail { get; set; }
    }
}
